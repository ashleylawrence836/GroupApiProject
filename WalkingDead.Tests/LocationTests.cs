using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WalkingDead.Models;
using WalkingDead.Services;

namespace WalkingDead.Tests
{
    [TestClass]
    public class LocationTests
    {
        [TestMethod]
        public void TestCreateLocationMethod1()
        {
            Guid userId = new Guid();
            LocationCreate testLocation = new LocationCreate()
            {
                Name = "Just some church",
                Description = "There's a priest with some baggage here"
            };

            LocationService service = new LocationService(userId);
            bool wasCreated = service.CreateLocation(testLocation);

            Assert.IsTrue(wasCreated);
        }

        [TestMethod]
        public void TestUpdateLocationMethod()
        {
            Guid userId = new Guid();
            
        }
    }
}
