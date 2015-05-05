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
}