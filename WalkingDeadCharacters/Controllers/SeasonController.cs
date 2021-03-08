using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WalkingDead.Models;
using WalkingDead.Services;

namespace WalkingDeadCharacters.Controllers
{
    [Authorize]
    public class SeasonController : ApiController
    {
        private SeasonService CreateSeasonService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var seasonService = new SeasonService(userId);
            return seasonService;
        }
        public IHttpActionResult Get()
        {
            SeasonService seasonService = CreateSeasonService();
            var seasons = seasonService.GetSeasons();
            return Ok(seasons);
        }

        public IHttpActionResult Post(SeasonCreate season)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateSeasonService();

            if (!service.CreateSeason(season))
                return InternalServerError();

            return Ok();
        }

    }

}
