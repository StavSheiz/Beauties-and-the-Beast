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

        public int FilterByCategory { get => filterByCategoryId; set => filterByCategoryId = value; }
        public bool SortByCalories { get => sortByCalories; set => sortByCalories = value; }
    }
}