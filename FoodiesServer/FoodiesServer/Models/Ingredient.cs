using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FoodiesServer.Models
{
    [DataContract]
    public class Ingredient
    {
        private int id;
        private string name;
        private int calories;
        private string pictureUrl;
        private string barcode;

        public Ingredient(int id, string name, int calories, string pictureUrl, string barcode)
        {
            this.Id = id;
            this.Name = name;
            this.Calories = calories;
            this.PictureUrl = pictureUrl;
            this.Barcode = barcode;
        }

        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Calories { get; set; }
        [DataMember]
        public string PictureUrl { get; set; }
        [DataMember]
        public string Barcode { get; set; }
    }
}