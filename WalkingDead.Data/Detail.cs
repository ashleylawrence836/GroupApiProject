using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDead.Data
{
    public class Detail
    {
        [Key]
        public int DetailId { get; set; }
        [Required]
        public string Strengths { get; set; }
        [Required]
        public string Weaknesses { get; set; }
        [Required]
        public string WeaponOfChoice { get; set; }
        public virtual Character Character { get; set; }

    }
}
