using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace DogWalkLogger.Models
{
    public class Walk
    {
        public ObjectId id { get; set; }
        public string name { get; set; }
        public decimal distance { get; set; }
        public string location { get; set; }
    }
}