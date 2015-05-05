using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace DogWalkLogger.Models
{
    /// <summary>
    /// Datacontext for SQL database containgin tables
    /// </summary>
    public class DWdb : DataContext
    {
        public DWdb(bool unit_test = false)
            : base(new SqlConnection())
        {
            if (!unit_test)
            {
                Connection.ConnectionString = "SERVER=localhost;DATABASE=DogWalk;UID=dwuser;PWD=Eb4d6iMQxi72dEfqWp3h";
            }
            else
            {
                Connection.ConnectionString = "SERVER=localhost;DATABASE=OsfcClassLibraryTest;UID=utuser;PWD=fpzh1vaf4A3KTJyOo2YH";
            }
        }

        public Table<dogwalk> dogwalks { get; set; }
        public Table<walker> walkers { get; set; }
        public Table<breed> breeds { get; set; }
        public Table<dog> dogs { get; set; }
        public Table<walk> walks { get; set; }
    }

    [Table(Name = "dogwalk")]
    public class dogwalk
    {
        [Column(DbType = "int not null", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }

        [Column(DbType = "int null")]
        public int? dogID { get; set; }

        [Column(DbType = "int null")]
        public int? walkID { get; set; }

        [Column(DbType = "int null")]
        public int? walkerID { get; set; }

        [Column(DbType = "datetime null")]
        public DateTime? started { get; set; }

        [Column(DbType = "varchar(max) null")]
        public string comment { get; set; }

        [Column(DbType = "int null")]
        public int? rating { get; set; }
    }

    [Table(Name = "breed")]
    public class breed
    {
        [Column(DbType = "int not null", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }

        [Column(DbType = "varchar(255) null")]
        public string name { get; set; }

        [Column(DbType = "varchar(max) null")]
        public string description { get; set; }
    }

    [Table(Name = "dog")]
    public class dog
    {
        [Column(DbType = "int not null", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }

        [Column(DbType = "varchar(255) null")]
        public string name { get; set; }

        [Column(DbType = "int null")]
        public int age { get; set; }

        [Column(DbType = "int null")]
        public int? breedID { get; set; }
    }

    [Table(Name = "walk")]
    public class walk
    {
        [Column(DbType = "int not null", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }

        [Column(DbType = "varchar(255) null")]
        public string name { get; set; }

        [Column(DbType = "decimal(18,2) null")]
        public decimal? distance { get; set; }

        [Column(DbType = "varchar(max) null")]
        public string location { get; set; }
    }

    [Table(Name = "walker")]
    public class walker
    {
        [Column(DbType = "int not null", IsPrimaryKey = true, IsDbGenerated = true)]
        public int id { get; set; }

        [Column(DbType = "varchar(255) null")]
        public string name { get; set; }

        [Column(DbType = "int null")]
        public int walkscompleted { get; set; }
    }
}