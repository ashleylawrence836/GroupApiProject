using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDead.Data
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Guid AddedByUserId { get; set; }


        [ForeignKey("FirstAppearance")]
        public int? FirstEpisodeId { get; set; }
        public virtual Episode FirstAppearance { get; set; }

        [ForeignKey("LastAppearance")]
        public int? LastEpisodeId { get; set; }
        public virtual Episode LastAppearance { get; set; }
    }
}
