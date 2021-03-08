using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDead.Models
{
   public class CharacterEdit
    {
        public int CharacterId { get; set; }

        [Display(Name = "Character")]
        public string Name { get; set; }

        [Display(Name = "Actor/Actress")]
        public string ActorName { get; set; }

        [Display(Name = "Character Features")]
        public string Features { get; set; }
        public string WeaponOfChoice { get; set; }
    }
}
