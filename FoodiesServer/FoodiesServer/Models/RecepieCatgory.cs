using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace FoodiesServer.Models
{
    [DataContract]
    public class RecepieCatgory
    {
        private int id;
        private string name;

        public RecepieCatgory(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
    }
}