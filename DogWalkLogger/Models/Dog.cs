﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;

namespace DogWalkLogger.Models
{
    public class Dog
    {
        public ObjectId id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public Breed breed { get; set; }
    }
}