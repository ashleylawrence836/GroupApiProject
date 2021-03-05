using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDead.Models
{
    public class DetailDetail
    {
        [Display(Name = "Strengths")]
        public string Strengths { get; set; }

        [Display(Name = "Weaknesses")]
        public string Weaknesses { get; set; }

        [Display(Name = "Weapon of choice")]
        public string WeaponOfChoice { get; set; }
        public int DetailId { get; set; }

    }
}
