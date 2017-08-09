using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodiesServer.Models
{
    public class User
    {
        private string name;
        private int id;
        private string password;
        private List<Ingredient> ingredients;

        public User(string name, int id, string password)
        {
            this.Name = name;
            this.Id = id;
            this.Password = password;
        }

        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}