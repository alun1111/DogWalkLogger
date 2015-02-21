using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogWalkLogger.Models
{
    public class Walk
    {
        public int walkID { get; set; }
        public string name { get; set; }
        public decimal distance { get; set; }
        public string location { get; set; }
    }
}