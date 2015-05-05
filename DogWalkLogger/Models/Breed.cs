using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DogWalkLogger.Models
{
    public class Breed
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    /// <summary>
    /// Data access for breed
    /// </summary>
    public class BreedService
    {
        private DWdb dw { get; set; }

        public BreedService()
        {
            dw = new DWdb();
        }

        public Breed getBreed(breed row)
        {
            Breed output = new Breed();

            output.name = row.name;
            output.id = row.id;
            output.description = row.description;

            return output;
        }

        public List<Breed> getAllDogs()
        {
            List<breed> tmp = dw.breeds.ToList();
            List<Breed> output = new List<Breed>();

            if (tmp != null)
            {
                foreach (var row in tmp)
                {
                    output.Add(getBreed(row));
                }
            }

            return output;
        }
    }
}