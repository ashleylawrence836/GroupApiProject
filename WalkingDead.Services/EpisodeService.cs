using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingDead.Data;
using WalkingDead.Models;
using WalkingDeadCharacters.Data;

namespace WalkingDead.Services
{
    public class EpisodeService
    {
        private readonly Guid _userID;

        public EpisodeService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateEpisode(EpisodeCreate episode)
        {
            Episode newEpisode = new Episode()
            {
                EpisodeId = episode.EpisodeId,
                Title = episode.EpisodeTitle,
                Description = episode.EpisodeDescription,
                AirDate = episode.AirDate,
                AddedByUserID = _userID
            };
            using (var context = new ApplicationDbContext())
            {
                context.Episodes.Add(newEpisode);
                return context.SaveChangesAsync().Result == 1;
            }
        }

        public IEnumerable<EpisodeDetail> GetEpisodes()
        {
            using (var context = new ApplicationDbContext())
            {
                var query = context.Episodes.Select(e => new EpisodeDetail
                {
                    EpisodeId = e.EpisodeId,
                    Description = e.Description,
                    Title = e.Title,
                    AirDate = e.AirDate
                });

                return query.ToArray();
            }
        }

        public Episode GetEpisodeByID(int episodeID)
        {
            using (var context = new ApplicationDbContext())
            {
                Episode episode = context.Episodes.Single
                    (e => e.EpisodeId == episodeID);

                return episode;
            }
        }

        public bool UpdateEpisode(EpisodeUpdate episode)
        {
            using (var context = new ApplicationDbContext())
            {
                Episode updateEpisode = context.Episodes.Single
                    (u => u.EpisodeId == episode.EpisodeId && u.AddedByUserID == _userID);

                if (episode.EpisodeTitle != null)
                {
                    updateEpisode.Title = episode.EpisodeTitle;
                }

                if (episode.EpisodeDescription != null)
                {
                    updateEpisode.Description = episode.EpisodeDescription;
                }

                if (episode.AirDate != null)
                {
                    updateEpisode.AirDate = episode.AirDate;
                }

                return context.SaveChangesAsync().Result > 0;
            }
        }

        public bool DeleteEpisode(int episodeId)
        {
            using (var context = new ApplicationDbContext())
            {
                Episode deleteEpisode = context.Episodes.Single
                    (d => d.EpisodeId == episodeId && d.AddedByUserID == _userID);

                context.Episodes.Remove(deleteEpisode);

                return context.SaveChangesAsync().Result == 1;
            }
        }
    }
}
