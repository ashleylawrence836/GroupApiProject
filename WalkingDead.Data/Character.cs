using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDead.Data
{
    public class Character
    {
        [Key]
        [Display(Name = "Character")]
        public string Name { get; set; }
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public DateTimeOffset Created { get; set; }
        public DateTimeOffset Expired { get; set; }

    }

}
