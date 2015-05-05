using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace DogWalkLogger.Models
{
    public class Walk
    {
        public int id { get; set; }
        public string name { get; set; }
        public decimal? distance { get; set; }
        public string location { get; set; }
    }

    /// <summary>
    /// Data access for walker
    /// </summary>
    public class WalkService
    {
        private DWdb dw { get; set; }

        public WalkService()
        {
            dw = new DWdb();
        }

        public Walk getWalk(walk row)
        {
            Walk output = new Walk();

            output.name = row.name;
            output.location = row.location;
            output.distance = row.distance;

            return output;
        }

        public List<Walk> getAllWalks()
        {
            List<walk> tmp = dw.walks.ToList();
            List<Walk> output = new List<Walk>();

            if (tmp != null)
            {
                foreach (var row in tmp)
                {
                    output.Add(getWalk(row));
                }
            }

            return output;
        }
    }
}