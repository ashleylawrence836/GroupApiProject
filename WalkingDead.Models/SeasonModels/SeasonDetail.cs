using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingDead.Data;
using WalkingDead.Models.EpisodeModels;
using WalkingDead.Models.LocationModels;
using WalkingDeadCharacters.Data;

namespace WalkingDead.Models
{
    public class SeasonDetail
    {
        [Display(Name = "Season")]
        public int SeasonId { get; set; }


        [Display(Name = "Location")]
        public LocationDetail StartingLocation
        {
            get
            {
                using (var context = new ApplicationDbContext())
                {
                    var season = context.Seasons.Single(
                        s => s.SeasonId == SeasonId);
                    var location = context.Locations.Single(
                        l => l.LocationId == season.StartingLocationId);

                    return new LocationDetail()
                    {
                        Name = location.Name,
                        Description = location.Description
                    };
                }
            }
        }

        public List<EpisodeListItem> Episodes
        {
            get
            {
                using (var context = new ApplicationDbContext())
                {
                    var episodes = context.Episodes.Where(
                        e => e.SeasonId == SeasonId);

                    List<EpisodeListItem> episodeDetails = new List<EpisodeListItem>();
                    foreach (Episode episode in episodes)
                    {
                        episodeDetails.Add(new EpisodeListItem()
                        {
                            SeasonId = episode.SeasonId,
                            EpisodeId = episode.EpisodeId,
                            Title = episode.Title,
                            Description = episode.Description,
                            AirDate = episode.AirDate
                        });
                    }

                    return episodeDetails;
                }
            }
        }
    }
}
