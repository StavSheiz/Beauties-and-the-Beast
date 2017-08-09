using FoodiesServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;

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
            return null;
        }

        public void AddIngridient(Ingredient ing, int userId)
        {

        }

        public void AddUser(User usr)
        {
            
        }

        public User AttemptLogin(User usr) {
            User u = null;

            try
            {
                sqlConnection.Open();
                sqlCommand.CommandText = "SELECT ID, USER_NAME, USER_PASSWORD FROM users WHERE USER_NAME=" + usr.Name + " AND USER_PASSWORD=" + usr.Password;
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

            return u;
        }

        public List<Recepie> GetRecepiesByFilter(RecepieFilter filter)
        {
            return null;
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
            catch(Exception ex)
            {

            }

            return lstCat;
        }
    }
}