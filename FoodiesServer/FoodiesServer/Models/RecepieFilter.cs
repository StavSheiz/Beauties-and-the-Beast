using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodiesServer.Models
{
    public class RecepieFilter
    {
        private RecepieCatgory filterByCategory;
        private bool sortByCalories;

        public RecepieFilter(RecepieCatgory filter, bool sort)
        {
            this.FilterByCategory = filter;
            this.SortByCalories = sort;
        }

        public RecepieCatgory FilterByCategory { get => filterByCategory; set => filterByCategory = value; }
        public bool SortByCalories { get => sortByCalories; set => sortByCalories = value; }
    }
}