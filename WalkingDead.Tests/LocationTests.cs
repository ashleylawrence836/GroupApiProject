using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WalkingDead.Data;
using WalkingDead.Models;
using WalkingDead.Models.LocationModels;
using WalkingDead.Services;
using WalkingDeadCharacters.Data;

namespace WalkingDead.Tests
{
    [TestClass]
    public class LocationTests
    {
        //Run these in order please
        [TestMethod]
        public void TestCreateLocationMethod()
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
        public void TestGetLocationsMethod()
        {
            Guid userId = new Guid();
            LocationService service = new LocationService(userId);

            List<LocationListItem> locations = service.GetLocations();

            Assert.IsTrue(locations.Count() > 0);
        }

        [TestMethod]
        public void TestGetLocationByIdMethod()
        {
            Guid userId = new Guid();
            LocationService service = new LocationService(userId);
            LocationListItem testLocation =
            service.GetLocationById(1);

            Assert.AreEqual(1, testLocation.LocationID);
        }

        [TestMethod]
        public void TestUpdateLocationMethod()
        {
            Guid userId = new Guid();
            LocationEdit model = new LocationEdit()
            {
                LocationID = 1,
                Name = "A CHURCH"
            };

            LocationService service = new LocationService(userId);
            bool wasUpdated = service.UpdateLocation(model);

            Assert.IsTrue(wasUpdated);
        }

        [TestMethod]
        public void TestDeleteLocationMethod()
        {
            Guid userId = new Guid();
            LocationService service = new LocationService(userId);

            using (var context = new ApplicationDbContext())
            {
                Location testLocation = context.Locations.Single(
                    e => e.LocationId == 1);
                userId = testLocation.AddedByUserId;

                bool wasDeleted = service.DeleteLocation(1);

                Assert.IsTrue(wasDeleted);
            }

        }
    }
}
