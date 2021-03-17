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

        public List<int> Episodes
        {
            get
            {
                using (var context = new ApplicationDbContext())
                {
                    var episodes = context.Episodes.Where(
                        e => e.SeasonId == SeasonId);

                    List<int> episodeIds = new List<int>();
                    foreach (Episode episode in episodes)
                    {
                        episodeIds.Add(episode.EpisodeId);
                    }

                    return episodeIds;
                }
            }
        }
    }
}
