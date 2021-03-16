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

        public string Details { get; set; }
        public string WeaponOfChoice { get; set; }

        public CharacterEdit () { }

        public CharacterEdit (string name, string actorName, string details, string weaponOfChoice ) { Name = name;
            ActorName = actorName;
            Details = details;
            WeaponOfChoice = weaponOfChoice;
        }
        
    }
}
