using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingDead.Data;
using WalkingDeadCharacters.Data;

namespace WalkingDead.Models.LocationModels
{
    public class LocationDetail
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
