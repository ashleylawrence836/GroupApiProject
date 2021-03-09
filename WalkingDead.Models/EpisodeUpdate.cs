using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDead.Models
{
    public class EpisodeUpdate
    {
        public int EpisodeId { get; set; }
        public string EpisodeTitle { get; set; }
        public string EpisodeDescription { get; set; }
        [Required]
        public DateTime AirDate { get; set; }
    }
}
