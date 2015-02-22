using System;
using DogWalkLogger.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DogWalkTests
{
    [TestClass]
    public class utDogWalk
    {
        [TestMethod]
        public void Method1()
        {
            DogWalkService dws = new DogWalkService();

            //dws.insertDogWalk();
            dws.getDogWalk();

            Assert.IsNotNull(dws.getDogWalk());
        }
    }
}
