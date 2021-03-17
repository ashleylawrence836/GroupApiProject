using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDead.Data
{
    public class Episode
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int EpisodeId { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime AirDate { get; set; }
        [Required]
        public Guid AddedByUserID { get; set; }

        [Required]
        [ForeignKey(nameof(Season))]
        public int SeasonId { get; set; }
        public virtual Season Season { get; set; }
        
        [Required]
        [ForeignKey(nameof(MainLocation))]
        public int LocationId { get; set; }
        public virtual Location MainLocation { get; set; }
    }
}
