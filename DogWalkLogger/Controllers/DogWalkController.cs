using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DogWalkLogger.Models;

namespace DogWalkLogger.Controllers
{
    public class DogWalkController : ApiController
    {
        // GET api/<controller>
        public List<DogWalk> Get()
        {
            DogWalkService dws = new DogWalkService();

            List<DogWalk> dw = dws.getAllDogWalks();

            return dw;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post(DogWalk dw)
        {
            DogWalkService dws = new DogWalkService();

            dws.insertDogWalk(dw);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}