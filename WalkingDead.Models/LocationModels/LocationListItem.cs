using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingDead.Data;
using WalkingDead.Models.EpisodeModels;
using WalkingDeadCharacters.Data;

namespace WalkingDead.Models.LocationModels
{
    public class LocationListItem
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Display(Name = "First Appeared In")]
        public EpisodeDetail FirstEpisode
        {
            get
            {
                using (var context = new ApplicationDbContext())
                { 
                    Location location = context.Locations.Single(
                        l => l.LocationId == LocationID);
                    Episode episode = context.Episodes.Single(
                        e => e.EpisodeId == location.FirstEpisodeId);
                    return new EpisodeDetail()
                    {
                        SeasonId = episode.SeasonId,
                        EpisodeId = episode.EpisodeId,
                        Title = episode.Title,
                        Description = episode.Description,
                        AirDate = episode.AirDate
                    };
                }
            }
        }
        [Display(Name = "Last Appeared In")]
        public EpisodeDetail LastEpisode
        {
            get
            {
                using (var context = new ApplicationDbContext())
                {
                    Location location = context.Locations.Single(
                        l => l.LocationId == LocationID);
                    Episode episode = context.Episodes.Single(
                        e => e.EpisodeId == location.LastEpisodeId);
                    return new EpisodeDetail()
                    {
                        SeasonId = episode.SeasonId,
                        EpisodeId = episode.EpisodeId,
                        Title = episode.Title,
                        Description = episode.Description,
                        AirDate = episode.AirDate
                    };
                }
            }
        }
    }
}
