using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDead.Models
{
    public class SeasonCreate
    {
        public int SeasonId { get; set; }
        public string Location { get; set; }
    }
}
