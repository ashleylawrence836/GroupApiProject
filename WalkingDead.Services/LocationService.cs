using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WalkingDead.Data;
using WalkingDead.Models;
using WalkingDead.Models.LocationModels;
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

        public List<LocationDetail> GetLocations()
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                        .Locations
                        .Select(
                            e =>
                                new LocationDetail
                                {
                                    
                                    Name = e.Name,
                                    Description = e.Description
                                });
                return query.ToList();
            }
        }

        public LocationDetail GetLocationById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .Locations
                        .Single(e => e.LocationId == id);
                return
                    new LocationDetail
                    {
                        Name = entity.Name,
                        Description = entity.Description
                    };
            }
        }

    }
}
