using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace DogWalkLogger.Models
{
    public class Dog
    {
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public Breed breed { get; set; }
    }

    /// <summary>
    /// Data access for dog
    /// </summary>
    public class DogService
    {
        private DWdb dw { get; set; }

        public DogService()
        {
            dw = new DWdb();
        }

        public Dog getDog(dog row)
        {
            Dog output = new Dog();

            output.id = row.id;
            output.name = row.name;
            output.age = row.age;
            //output.breed = 0; // row.breedID;

            return output;
        }

        public List<Dog> getAllDogs()
        {
            List<dog> tmp = dw.dogs.ToList();
            List<Dog> output = new List<Dog>();

            if (tmp != null)
            {
                foreach (var row in tmp)
                {
                    output.Add(getDog(row));
                }
            }

            return output;
        }
    }
}