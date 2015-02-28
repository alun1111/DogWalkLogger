using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoDB.Driver.GridFS;
using MongoDB.Driver.Linq;

namespace DogWalkLogger.Models
{
    public class DogWalk
    {
        public ObjectId id { get; set; }
        //public Dog dogwalked { get; set; }
        //public Walk walk { get; set; }
        //public Walker walker { get; set; }
        public string dogWalked { get; set; }
        public string walk { get; set; }
        public string walker { get; set; }
        public DateTime start { get; set; }
        public string comment { get; set; }
        public int rating { get; set; }
    }

    /// <summary>
    /// Data access for dog walk
    /// </summary>
    public class DogWalkService
    {
        private string connectionString;
        private MongoClient client;
        private MongoServer server;
        private MongoDatabase database;
        private MongoCollection collection;

        public DogWalkService()
        {
            // Connect to MongoDB instance
            connectionString = "mongodb://localhost";
            client = new MongoClient(connectionString);
            server = client.GetServer();
            database = server.GetDatabase("dogwalklogger");
            collection = database.GetCollection<DogWalk>("DogWalks");
        }

        public DogWalk getDogWalk()
        {
            // "DogWalks" is the name of the collection (pluralise as in Linq to SQL)
            var query = Query<DogWalk>.EQ(e => e.walker, "Alun");

            var entity = collection.FindOneAs<DogWalk>(query);

            return entity;
            
        }

        public List<DogWalk> getAllDogWalks()
        {
            List<DogWalk> entity = collection.FindAllAs<DogWalk>().ToList();

            return entity;
        }

        public void insertDogWalk(DogWalk entity)
        {
            collection.Insert(entity);
            var id = entity.id; // Insert will set the Id if necessary (as it was in this example)
        }
    }
}