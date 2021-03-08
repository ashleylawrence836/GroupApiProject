using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDead.Data
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ActorName { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        [ForeignKey(nameof(Episode))]
        public int EpisodeId { get; set; }
        public virtual Episode Episode { get; set; }
        [Required]
        public string Details { get; set; }
        [Required]
        public string WeaponOfChoice { get; set; }
    }

}
