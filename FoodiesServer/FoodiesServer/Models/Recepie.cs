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

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Text { get => text; set => text = value; }
        public List<Ingredient> Ingredients { get => ingredients; set => ingredients = value; }
    }
}