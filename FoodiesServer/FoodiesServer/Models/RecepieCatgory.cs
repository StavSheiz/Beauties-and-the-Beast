using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodiesServer.Models
{
    public class RecepieCatgory
    {
        private int id;
        private string name;

        public RecepieCatgory(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
    }
}