using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDead.Data
{
    public class Season
    {
        [Key]
        public int SeasonId { get; set; }
        [Required]
        public string Location { get; set; }

    }
}
