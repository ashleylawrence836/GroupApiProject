using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDead.Models
{
    public class DetailCreate
    {
        public string Strengths { get; set; }
        public string Weaknesses { get; set; }
        public string WeaponOfChoice { get; set; }
        public int CharacterId { get; set; }
    }
}
