using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingDead.Data;
using WalkingDead.Models.LocationModels;
using WalkingDeadCharacters.Data;

namespace WalkingDead.Models
{
    public class EpisodeListItem
    {
        [Display(Name = "Season")]
        public int SeasonId { get; set; }
        [Display(Name = "Episode")]
        public int EpisodeId { get; set; }
        [Display(Name = "Episode Title")]
        public string Title { get; set; }
        [Display(Name = "Episode Location")]
        public string Location
        {
            get
            {
                using (var context = new ApplicationDbContext())
                {
                    var episode = context.Episodes.Single(
                        e => e.EpisodeId == EpisodeId);
                    var location = context.Locations.Single(
                        l => l.LocationId == episode.LocationId);

                    return location.Name;
                }
            }
        }
        [Display(Name = "Episode Desc")]
        public string Description { get; set; }
        [Display(Name = "Aired On")]
        public DateTime AirDate { get; set; }
    }
}
