using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingDead.Data;
using WalkingDead.Models;
using WalkingDeadCharacters.Data;

namespace WalkingDead.Services
{
    public class LocationService
    {
        private readonly Guid _userId;

        public LocationService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateLocation(LocationCreate model)
        {
            Location newLocation = new Location()
            {
                Name = model.Name,
                Description = model.Description,
                AddedByUserId = _userId
            };

            using (var context = new ApplicationDbContext())
            {
                context.Locations.Add(newLocation);
                return context.SaveChangesAsync().Result == 1;
            }
        }


    }
}
