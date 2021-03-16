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
        public int SeasonId { get; set; }
        [Required]
        public int EpisodeId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime AirDate { get; set; }
    }
}
