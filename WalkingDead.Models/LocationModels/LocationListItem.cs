﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkingDead.Models.LocationModels
{
    public class LocationListItem
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        //public int FirstEpisodeId { get; set; }
        //public int LastEpisodeId { get; set; }
    }
}