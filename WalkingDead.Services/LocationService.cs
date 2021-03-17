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
            Location newLocation = new Location();

            newLocation.Name = model.Name;
            newLocation.Description = model.Description;
            if (model.FirstEpisodeID != null)
            {
                newLocation.FirstEpisodeId = model.FirstEpisodeID;
            }
            if (model.LastEpisodeID != null)
            {
                newLocation.LastEpisodeId = model.LastEpisodeID;

            }
            newLocation.AddedByUserId = _userId;

            using (var context = new ApplicationDbContext())
            {
                context.Locations.Add(newLocation);
                return context.SaveChangesAsync().Result == 1;
            }
        }

        public List<LocationListItem> GetLocations()
        {
            using (var context = new ApplicationDbContext())
            {
                var query =
                    context
                        .Locations
                        .Select(
                            e =>
                                new LocationListItem
                                {
                                    LocationID = e.LocationId,
                                    Name = e.Name,
                                    Description = e.Description,

                                });
                return query.ToList();
            }
        }

        public LocationListItem GetLocationById(int id)
        {
            using (var context = new ApplicationDbContext())
            {
                var entity =
                    context
                        .Locations
                        .Single(e => e.LocationId == id);
                return
                    new LocationListItem
                    {
                        LocationID = entity.LocationId,
                        Name = entity.Name,
                        Description = entity.Description
                    };
            }
        }

        public bool UpdateLocation(LocationEdit model)
        {
            using (var context = new ApplicationDbContext())
            {
                Location updateLocation = context.Locations.Single
                    (e => e.LocationId == model.LocationID);

                if (model.Name != null)
                {
                    updateLocation.Name = model.Name;
                }

                if (model.Description != null)
                {
                    updateLocation.Description = model.Description;
                }

                updateLocation.FirstEpisodeId = model.FirstEpisodeId;
                updateLocation.LastEpisodeId = model.LastEpisodeId;

                return context.SaveChangesAsync().Result >= 1;
            };
        }

        public bool DeleteLocation(int locationId)
        {
            using (var context = new ApplicationDbContext())
            {
                Location deleteLocation = context.Locations.Single(
                    e => e.LocationId == locationId && e.AddedByUserId == _userId);

                context.Locations.Remove(deleteLocation);

                return context.SaveChangesAsync().Result == 1;
            }
        }
    }
}
