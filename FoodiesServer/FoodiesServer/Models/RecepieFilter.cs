using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FoodiesServer.Models
{
    [DataContract]
    public class RecepieFilter
    {
        private int filterByCategoryId;
        private bool sortByCalories;

        public RecepieFilter(int filter, bool sort)
        {
            this.FilterByCategory = filter;
            this.SortByCalories = sort;
        }

        [DataMember]
        public int FilterByCategory { get; set; }
        [DataMember]
        public bool SortByCalories { get; set; }
    }
}