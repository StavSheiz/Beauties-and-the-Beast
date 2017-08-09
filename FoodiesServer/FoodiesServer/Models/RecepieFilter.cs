using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodiesServer.Models
{
    public class RecepieFilter
    {
        private int filterByCategoryId;
        private bool sortByCalories;

        public RecepieFilter(int filter, bool sort)
        {
            this.FilterByCategory = filter;
            this.SortByCalories = sort;
        }

        public int FilterByCategory { get; set; }
        public bool SortByCalories { get; set; }
    }
}