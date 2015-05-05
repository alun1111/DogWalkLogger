using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace DogWalkLogger.Models
{
    public class Walker
    {
        public int id { get; set; }
        public string name { get; set; }
        public int walkscompleted { get; set; }
    }

    /// <summary>
    /// Data access for walker
    /// </summary>
    public class WalkerService
    {
        private DWdb dw { get; set; }

        public WalkerService()
        {
            dw = new DWdb();
        }

        public Walker getWalker(walker row)
        {
            Walker output = new Walker();

            output.name = row.name;

            return output;
        }

        public List<Walker> getAllWalkers()
        {
            List<walker> tmp = dw.walkers.ToList();
            List<Walker> output = new List<Walker>();

            if (tmp != null)
            {
                foreach (var row in tmp)
                {
                    output.Add(getWalker(row));
                }
            }

            return output;
        }
    }
}