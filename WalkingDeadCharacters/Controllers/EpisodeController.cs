using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WalkingDead.Data;
using WalkingDead.Models;
using WalkingDead.Services;

namespace WalkingDeadCharacters.Controllers
{
    public class EpisodeController : ApiController
    {

        private EpisodeService CreateService()
        {
            Guid userId = Guid.Parse(User.Identity.GetUserId());
            var episodeService = new EpisodeService(userId);
            return episodeService;
        }

        [HttpPost]
        public IHttpActionResult PostEpisode(EpisodeCreate episode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EpisodeService episodeService = CreateService();

            if (episode == default)
            {
                return NotFound();
            }

            if (!episodeService.CreateEpisode(episode))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAllEpisodes()
        {
            EpisodeService episodeService = CreateService();
            var episodes = episodeService.GetEpisodes();
            return Ok(episodes);
        }

        [HttpGet]
        public IHttpActionResult GetEpisodeByID([FromUri]int episodeId)
        {
            EpisodeService episodeService = CreateService();
            Episode episode = episodeService.GetEpisodeByID(episodeId);

            EpisodeDetail detail = new EpisodeDetail()
            {
                EpisodeId = episode.EpisodeId,
                Title = episode.Title,
                Description = episode.Description,
                AirDate = episode.AirDate
            };

            if (episode == default)
            {
                return NotFound();
            }

            return Ok(detail);
        }

        [HttpPut]
        public IHttpActionResult PutEpisode(EpisodeUpdate episode)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            EpisodeService episodeService = CreateService();

            Episode updateEpisode = episodeService.GetEpisodeByID(episode.EpisodeId);

            if (updateEpisode == default)
            {
                return NotFound();
            }

            if (!episodeService.UpdateEpisode(episode))
            {
                return InternalServerError();
            }

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult DeleteEpisode([FromUri]int episodeId)
        {
            EpisodeService episodeService = CreateService();

            Episode deleteEpisode = episodeService.GetEpisodeByID(episodeId);

            if (deleteEpisode == default)
            {
                return NotFound();
            }

            if (!episodeService.DeleteEpisode(episodeId))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
