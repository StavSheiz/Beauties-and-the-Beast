using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodiesServer.Models
{
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

        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public List<Ingredient> Ingredients { get; set; }
    }
}