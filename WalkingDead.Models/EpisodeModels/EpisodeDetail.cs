using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDead.Models.EpisodeModels
{
    public class EpisodeDetail
    {
        [Display(Name = "Season")]
        public int SeasonId { get; set; }
        [Display(Name = "Episode")]
        public int EpisodeId { get; set; }
        [Display(Name = "Episode Title")]
        public string Title { get; set; }
        [Display(Name = "Episode Desc")]
        public string Description { get; set; }
        [Display(Name = "Aired On")]
        public DateTime AirDate { get; set; }
    }
}
