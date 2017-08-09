using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodiesServer.Models
{
    public class Ingredient
    {
        private int id;
        private string name;
        private int calories;
        private string pictureUrl;

        public Ingredient(int id, string name, int calories, string pictureUrl)
        {
            this.Id = id;
            this.Name = name;
            this.Calories = calories;
            this.PictureUrl = pictureUrl;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Calories { get => calories; set => calories = value; }
        public string PictureUrl { get => pictureUrl; set => pictureUrl = value; }
    }
}