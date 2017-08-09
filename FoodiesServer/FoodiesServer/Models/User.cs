using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FoodiesServer.Models
{
    [DataContract]
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

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public List<Ingredient> Ingredients { get; set; }
    }
}