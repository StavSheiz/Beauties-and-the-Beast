﻿using FoodiesServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Net;

namespace FoodiesServer.DAL
{
    public class FoodiesDAL
    {
        private string ConnectionString;
        private MySqlCommand sqlCommand;
        private MySqlConnection sqlConnection;

        public FoodiesDAL()
        {
            ConnectionString = "Server=foodiesmysql.citoxtcog7i3.us-east-2.rds.amazonaws.com;Port=3306;Database=foodies;uid=admin;password=Aa123456;charset=utf8";
            sqlConnection = new MySqlConnection(ConnectionString);
            sqlCommand = new MySqlCommand("" , sqlConnection);
        }

        public List<Ingredient> GetAllIngredients(int UserId)
        {
            List<Ingredient> lstIngs = new List<Ingredient>();
            try
            {
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                    sqlCommand.CommandText = "SELECT ID, PRODUCT_NAME, CALORIES, IMAGE, BARCODE FROM products WHERE ID IN (SELECT PRODUCT_ID FROM usersproducts WHERE USER_ID=" + UserId + ")";
                    MySqlDataReader reader = sqlCommand.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32("ID");
                        string name = reader.GetString("PRODUCT_NAME");
                        int calories = reader.GetInt32("CALORIES");
                        string image = reader.GetString("IMAGE");
                        string barcode = reader.GetString("BARCODE");

                        Ingredient i = new Ingredient(id, name, calories, image);
                        lstIngs.Add(i);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConnection.Close();
            }

            return lstIngs;
        }


        public void AddIngridient(string barcode, int userId)
        {
            try
            {
                Ingredient ing;
                if (sqlConnection.State == System.Data.ConnectionState.Closed)
                {
                    sqlConnection.Open();
                    sqlCommand.CommandText = "SELECT * FROM products WHERE BARCODE=" + barcode;
                    MySqlDataReader reader = sqlCommand.ExecuteReader();
                    if (!reader.HasRows)
                    {
                        ing = GetIngridientForBarcode(barcode);

                        sqlCommand.CommandText = "INSERT INTO products (ID,PRODUCT_NAME,CALORIES,BARCODE,IMAGE) VALUES(" + ing.Id + "," + ing.Name + "," + ing.Calories + "," + ing.Barcode + "" + ing.PictureUrl + ")";
                        sqlCommand.ExecuteNonQuery();
                    }
                    else
                    {
                        reader.Read();
                        int id = reader.GetInt32("ID");
                        string name = reader.GetString("PRODUCT_NAME");
                        int calories = reader.GetInt32("CALORIES");
                        string image = reader.GetString("IMAGE");
                        reader.Close();
                        ing = new Ingredient(id, name, calories, image, barcode);
                    }

                    sqlCommand.CommandText = "INSERT INTO usersproducts (PRODUCT_ID, USER_ID) VALUES(" + ing.Id + "," + userId + ")";
                    sqlCommand.ExecuteNonQuery();
                }
            }
            catch (Exception ex){ }
            finally
            {
                sqlConnection.Close();
            }
        }

        private Ingredient GetIngridientForBarcode(string barcode)
        {
            string request_template = "http://www.shufersal.co.il/layouts/Shufersal_Pages/ajax.aspx?searchText=";
            string req_text = request_template + barcode;

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(req_text);

            var response = req.GetResponse();
            return new Ingredient(1, "", 1, "", "");
        }

        public void AddUser(User usr)
        {
            try
            {
                sqlConnection.Open();
                sqlCommand.CommandText = "INSERT INTO users (USER_NAME,USER_PASSWORD) VALUES("+usr.Name + ",'" + usr.Password + "')";
                sqlCommand.ExecuteNonQuery();
            }
            catch(Exception ex) { }
            finally
            {
                sqlConnection.Close();
            }
        }

        public User AttemptLogin(User usr) {
            User u = null;

            try
            {
                sqlConnection.Open();
                sqlCommand.CommandText = "SELECT ID, USER_NAME, USER_PASSWORD FROM users WHERE USER_NAME='" + usr.Name + "' AND USER_PASSWORD='" + usr.Password +"'";
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    int id = reader.GetInt32("ID");
                    string name = reader.GetString("USER_NAME");
                    string password = reader.GetString("USER_PASSWORD");

                    u = new User(name, id, password);
                }
            }
            catch{ }
            finally
            {
                sqlConnection.Close();
            }

            return u;
        }

        public List<Recepie> GetRecepiesByFilter(RecepieFilter filter, int userId)
        {
            List<Recepie> lstRes = new List<Recepie>();

            List<Recepie> lstFinalRec = new List<Recepie>();
            try
            {
                sqlConnection.Open();
                string where = "recepiecalory.RECEPY_ID = recepies.ID ";
                if (filter.FilterByCategory != -1) {
                    where += " AND recepies.ID IN (SELECT RECEPY_ID FROM recepycategory WHERE CATEGORY_ID=" + filter.FilterByCategory + ")";
                }
                sqlCommand.CommandText = "SELECT recepies.ID, recepies.RECEPY_NAME, recepies.RECEPY_TEXT, recepies.IMAGE, recepiecalory.RECEPY_SUM FROM recepies,recepiecalory WHERE "+ where;
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("ID");
                    string name = reader.GetString("RECEPY_NAME");
                    string text = reader.GetString("RECEPY_TEXT");
                    string pictureUrl = reader.GetString("IMAGE");
                    int cals = reader.GetInt32("RECEPY_SUM");

                    Recepie res = new Recepie(id,name,text);
                    res.Calories = cals;
                    res.pictureUrl = pictureUrl;
                    lstRes.Add(res);
                }

                
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConnection.Close();
            }

            if (lstRes.Count > 0) {
                List<Ingredient> lstUserIng = new List<Ingredient>();
                lstUserIng = GetAllIngredients(userId);

                foreach (Recepie res in lstRes)
                {
                    bool ok = false;
                    List<Ingredient> lstIng = new List<Ingredient>();

                    lstIng = GetAllRecepieIngs(res.Id);

                    foreach (Ingredient ing in lstIng)
                    {
                        ok = false;
                        foreach (Ingredient ingg in lstUserIng)
                        {
                            if (ingg.Id== ing.Id)
                            {
                                ok = true;
                            }
                        }

                        if (!ok) {
                            break;
                        }
                    }

                    if (ok)
                    {
                        lstFinalRec.Add(res);
                    }
                }
            }

            return lstFinalRec;
        }

        public List<RecepieCatgory> GetAllCategories()
        {
            RecepieCatgory cat = null;
            List<RecepieCatgory> lstCat = new List<RecepieCatgory>();
            try
            {
                sqlConnection.Open();
                sqlCommand.CommandText = "SELECT ID, CATEGORY_NAME FROM categories";
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("ID");
                    string name = reader.GetString("CATEGORY_NAME");

                    cat = new RecepieCatgory(id, name);
                    lstCat.Add(cat);
                }
            }
            catch (Exception ex)
            {

            }
            finally {
                sqlConnection.Close();
            }

            return lstCat;
        }

        internal List<Ingredient> GetAllRecepieIngs(int recepieId)
        {
            List<Ingredient> lstIngs = new List<Ingredient>();
            try
            {
                sqlConnection.Open();
                sqlCommand.CommandText = "SELECT ID, PRODUCT_NAME, CALORIES, IMAGE, BARCODE FROM products WHERE ID IN (SELECT PRODUCT_ID FROM recepiesproducts WHERE RECEPY_ID=" + recepieId +" )";
                MySqlDataReader reader = sqlCommand.ExecuteReader();
                while (reader.Read())
                {
                    int id = reader.GetInt32("ID");
                    string name = reader.GetString("PRODUCT_NAME");
                    int calories = reader.GetInt32("CALORIES");
                    string image = reader.GetString("IMAGE");
                    string barcode = reader.GetString("BARCODE");

                    Ingredient i = new Ingredient(id, name, calories, image,barcode);
                    lstIngs.Add(i);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                sqlConnection.Close();
            }

            return lstIngs;
        }
    }
}