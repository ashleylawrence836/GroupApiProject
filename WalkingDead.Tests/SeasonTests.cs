using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WalkingDead.Data;
using WalkingDead.Models;
using WalkingDead.Services;

namespace WalkingDead.Tests
{
    [TestClass]
    public class SeasonTests
    {
        //If you tested Episodes first, clear database before testing
        [TestMethod]
        public void SeasonCreateDeleteTest()
        {
            SeasonCreate seasonOne = new SeasonCreate();
            seasonOne.SeasonId = 1;
            seasonOne.Location = "Atlanta";

            Guid userID = new Guid();
            SeasonService service = new SeasonService(userID);

            bool wasAdded = service.CreateSeason(seasonOne);
            Assert.IsTrue(wasAdded);

            bool wasDeleted = service.DeleteSeason(1);
            Assert.IsTrue(wasDeleted);
        }

        [TestMethod]
        public void GetSeasonTest()
        {
            Guid userID = new Guid();
            SeasonCreate seasonOne = new SeasonCreate();
            seasonOne.SeasonId = 1;
            seasonOne.Location = "Atlanta";


            SeasonService service = new SeasonService(userID);

            service.CreateSeason(seasonOne);

            IEnumerable<SeasonDetail> details = service.GetSeasons();

            bool wasFound = details.Count() > 0;

            Assert.IsTrue(wasFound);
        }

        [TestMethod]
        public void GetSeasonByIdTest()
        {
            Guid userId = new Guid();
            SeasonService service = new SeasonService(userId);
            SeasonDetail season = new SeasonDetail();
            season.SeasonId = 1;
            season.Location = "Highway/Hershell's Farm";

            SeasonDetail seasonOne = service.GetSeasonById(season.SeasonId);

            Assert.AreEqual(seasonOne.SeasonId, season.SeasonId);
        }

        [TestMethod]
        public void UpdateSeasonTest()
        {
            Guid userId = new Guid();
            SeasonService service = new SeasonService(userId);
            SeasonEdit update = new SeasonEdit();

            update.SeasonId = 1;
            update.Location = "The Prison";

            Assert.IsTrue(service.UpdateSeason(update));
        }


    }
}
