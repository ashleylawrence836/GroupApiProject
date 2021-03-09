using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingDead.Data;

namespace WalkingDead.Models
{
    public class CharacterCreate
    {
        [Required]
        public string Name { get; set; }
        public string ActorName { get; set; }
        public string WeaponOfChoice { get; set; }
        public string Details { get; set; }
        public int FirstEpisodeId { get; set; }
        public int LastEpisodeId { get; set; }
    }
}
