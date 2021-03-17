using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using WalkingDead.Models;
using WalkingDead.Models.LocationModels;
using WalkingDead.Services;

namespace WalkingDeadCharacters.Controllers
{
    [Authorize]
    public class LocationController : ApiController
    {

        private LocationService CreateLocationService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var locationService = new LocationService(userId);
            return locationService;
        }

        public IHttpActionResult Get()
        {
            LocationService locationService = CreateLocationService();
            var locations = locationService.GetLocations();
            return Ok(locations);

        }

        public IHttpActionResult GetLocationById(int id)
        {
            LocationService locationService = CreateLocationService();
            var location = locationService.GetLocationById(id);
            return Ok(location);
        }

        public IHttpActionResult Post(LocationCreate location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();
            if (!service.CreateLocation(location))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Put(LocationEdit location)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateLocationService();
            if (!service.UpdateLocation(location))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int Id)
        {
            var service = CreateLocationService();

            if (!service.DeleteLocation(Id))
                return InternalServerError();

            return Ok();
        }

    }
}
