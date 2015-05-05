using System;
using System.Collections.Generic;

namespace DogWalkLogger.Models
{
    public class DogWalk
    {
        public int? id { get; set; }
        //public Dog dogwalked { get; set; }
        //public Walk walk { get; set; }
        //public Walker walker { get; set; }
        public string dogWalked { get; set; }
        public string walk { get; set; }
        public string walker { get; set; }
        public DateTime? start { get; set; }
        public string comment { get; set; }
        public int? rating { get; set; }
    }

    /// <summary>
    /// Data access for dog walk
    /// </summary>
    public class DogWalkService
    {
        public DogWalkService()
        {
            DWdb dw = new DWdb();
        }

        public DogWalk getDogWalk(dogwalk row)
        {
            DogWalk output = new DogWalk();

            output.id = row.id;
            output.dogWalked = Convert.ToString(row.dogID); //todo
            output.walk = Convert.ToString(row.walkID); //todo
            output.walker = Convert.ToString(row.walkerID); //todo
            output.start = row.started;
            output.rating = row.rating;

            return null;
            
        }

        public List<DogWalk> getAllDogWalks()
        {

            return null;
        }

        public void insertDogWalk(DogWalk entity)
        {

        }
    }
}