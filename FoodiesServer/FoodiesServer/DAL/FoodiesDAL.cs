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
            ConnectionString = WebConfigurationManager.AppSettings["ConnectionStrings"];
            sqlConnection = new MySqlConnection(ConnectionString);
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
            return null;
        }

        public List<Recepie> GetRecepiesByFilter(RecepieFilter filter)
        {
            return null;
        }

        public List<RecepieCatgory> GetAllCategories()
        {
            return null;
        }
    }
}