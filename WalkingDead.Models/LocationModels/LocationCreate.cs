using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDead.Models
{
    public class LocationCreate
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public int FirstEpisodeID { get; set; }
        public int LastEpisodeID { get; set; }
    }
}
