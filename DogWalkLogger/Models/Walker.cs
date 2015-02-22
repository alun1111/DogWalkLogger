using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace DogWalkLogger.Models
{
    public class Walker
    {
        public ObjectId id { get; set; }
        public string name { get; set; }
        public int walkscompleted { get; set; }
    }
}