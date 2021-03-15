using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingDead.Data;

namespace WalkingDead.Models
{
    public class CharacterDetail
    {
        public int CharacterId { get; set; }
        [Display(Name = "Character")]
        public string Name { get; set; }
        [Display(Name = "Actor/Actress")]
        public string ActorName { get; set; }
        [Display(Name = "Season introduced")]
        public int? FirstEpisodeId { get; set; }
        [Display(Name = "Last Appearance")]
        public int? LastEpisodeId { get; set; }
        [Display(Name = "Character Description")]
        public string Details { get; set; }
        public string WeaponOfChoice { get; set; }
    }
}
