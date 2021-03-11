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
        [TestMethod]
        public void TestCreateEpisodeMethod()
        {
            Guid userID = new Guid();

            SeasonCreate testSeason = new SeasonCreate()
            {
                SeasonId = 2,
                Location = "The Highway/Hershel's Farm"
            };

            SeasonService seasonService = new SeasonService(userID);
            seasonService.CreateSeason(testSeason);

            EpisodeCreate testEpisode = new EpisodeCreate()
            {
                SeasonId = 1,
                EpisodeId = 2,
                Title = "Days Gone",
                Description = "This is a test",
                AirDate = DateTime.Now
            };

            EpisodeService service = new EpisodeService(userID);
            Assert.IsTrue(service.CreateEpisode(testEpisode));
        }

        [TestMethod]
        public void TestGetEpisodesMethod()
        {
            Guid userID = new Guid();

            EpisodeService service = new EpisodeService(userID);
            IEnumerable<EpisodeDetail> details = service.GetEpisodes();

            bool wasFound = details.Count() > 0;

            Assert.IsTrue(wasFound);
        }

        [TestMethod]
        public void TestGetEpisodeByIDMethod()
        {
            Guid userID = new Guid();
            int episodeID = 1;
            
        }
    }
}
