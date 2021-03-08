using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDead.Data
{
    public class Season
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int SeasonId { get; set; }
        [Required]
        public string Location { get; set; }
        public virtual List<Episode> Episodes { get; set; } = new List<Episode>();
    }
}
