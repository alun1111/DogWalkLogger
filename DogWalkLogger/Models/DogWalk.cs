using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private DWdb dw { get; set; }

        public DogWalkService()
        {
            dw = new DWdb();
        }

        public DogWalk getDogWalk(dogwalk row)
        {
            DogWalk output = new DogWalk();

            DogService ds = new DogService();
            WalkService ws = new WalkService();
            WalkerService was = new WalkerService();

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
            List<dogwalk> tmp = dw.dogwalks.ToList();
            List<DogWalk> output = new List<DogWalk>();

            if (tmp != null)
            {
                foreach (var row in tmp)
                {
                    output.Add(getDogWalk(row));
                }
            }

            return output;
        }

        public void insertDogWalk(DogWalk row)
        {
            dogwalk output = new dogwalk();

            output.dogID = 0; //dw.dogWalked; 
            output.walkID = 0; //dw.walk;
            output.walkerID = 0; //dw.walker;
            output.started = row.start;
            output.rating = row.rating;

            dw.dogwalks.InsertOnSubmit(output);

            dw.SubmitChanges();
        }
    }
}