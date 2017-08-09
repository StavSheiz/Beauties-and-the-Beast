using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FoodiesServer.Models
{
    [DataContract]
    public class Recepie
    {
        private int id;
        private string name;
        private string text;
        private List<Ingredient> ingredients;

        public Recepie(int id, string name, string text)
        {
            this.Id = id;
            this.Name = name;
            this.Text = text;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Text { get; set; }
        [DataMember]
        public List<Ingredient> Ingredients { get; set; }
    }
}