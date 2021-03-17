using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WalkingDead.Data;
using WalkingDead.Models;
using WalkingDead.Services;
using WalkingDeadCharacters.Data;

namespace WalkingDead.Tests
{
    [TestClass]
    public class EpisodeTests
    {
        //All tests use the episode made in the first test
        [TestMethod]
        public void TestCreateEpisodeMethod()
        {
            Guid userID = new Guid();
            LocationCreate testLocation = new LocationCreate()
            {
                Name = "TestLocation",
                Description = "Test"
            };

            LocationService locationService = new LocationService(userID);
            locationService.CreateLocation(testLocation);

            SeasonCreate testSeason = new SeasonCreate()
            {
                SeasonId = 1,
                StartingLocationId = 1,
            };

            SeasonService seasonService = new SeasonService(userID);
            seasonService.CreateSeason(testSeason);

            EpisodeCreate testEpisode = new EpisodeCreate()
            {
                SeasonId = 1,
                EpisodeId = 1,
                Title = "Days Gone",
                Description = "This is a test",
                AirDate = DateTime.Now,
                LocationId = 1
            };

            EpisodeService service = new EpisodeService(userID);
            Assert.IsTrue(service.CreateEpisode(testEpisode));
        }

        [TestMethod]
        public void TestGetEpisodesMethod()
        {
            Guid userID = new Guid();

            EpisodeService service = new EpisodeService(userID);
            IEnumerable<EpisodeListItem> details = service.GetEpisodes();

            bool wasFound = details.Count() > 0;

            Assert.IsTrue(wasFound);
        }

        [TestMethod]
        public void TestGetEpisodeByIDMethod()
        {
            Guid userID = new Guid();

            EpisodeService service = new EpisodeService(userID);
            EpisodeListItem testDetail = new EpisodeListItem()
            {
                SeasonId = 1,
                EpisodeId = 1,
                Title = "Days Gone",
                Description = "This is a test",
                AirDate = DateTime.Now
            };

            Episode testEpisode = service.GetEpisodeByID(testDetail.EpisodeId);

            Assert.AreEqual(testDetail.EpisodeId, testEpisode.EpisodeId);
        }

        [TestMethod]
        public void TestUpdateEpisodeMethod()
        {
            Guid userID = new Guid();

            EpisodeService service = new EpisodeService(userID);
            EpisodeUpdate updateEpisode = new EpisodeUpdate()
            {
                Title = "Banana fun",
                AirDate = DateTime.Now
            };

            Assert.IsTrue(service.UpdateEpisode(updateEpisode, 1));
        }

        [TestMethod]
        public void TestDeleteEpisodeMethod()
        {
            
            Guid userID = new Guid();

            EpisodeService service = new EpisodeService(userID);

            Episode episode = service.GetEpisodeByID(1);
            userID = episode.AddedByUserID;

            bool wasRemoved = service.DeleteEpisode(1);

            Assert.IsTrue(wasRemoved);
        }
    }
}
