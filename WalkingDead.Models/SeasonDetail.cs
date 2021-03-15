using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDead.Models
{
    public class SeasonDetail
    {
        [Display(Name = "Season")]
        public int SeasonId { get; set; }

        [Display(Name = "Location")]
        public string Location { get; set; }

        public List<EpisodeDetail> Episodes { get; set; }
    }
}
