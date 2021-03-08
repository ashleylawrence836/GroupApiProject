using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDead.Models
{
    public class EpisodeCreate
    {
        [Required]
        public int EpisodeId { get; set; }
        [Required]
        public string EpisodeTitle { get; set; }
        [Required]
        public string EpisodeDescription { get; set; }
        [Required]
        public DateTime AirDate { get; set; }
    }
}
