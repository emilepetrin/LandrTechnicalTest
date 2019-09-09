using LandrTest.Models;
using LandrTest.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;

namespace LandrTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeolocationController : ControllerBase
    {
        private readonly IGeolocalizationService _geolocalizationService;

        public GeolocationController(IGeolocalizationService geolocalizationService)
        {
            _geolocalizationService = geolocalizationService;
        }

        [HttpGet]
        public ActionResult<GeolocationInformations> Get()
        {
            var ip = Request.HttpContext.Connection.RemoteIpAddress;
            var location = _geolocalizationService.GetLocation(ip);
            if (location == null)
                return NotFound(ip.ToString());

            return Ok(location);
        }

        [HttpPost]
        public ActionResult<List<GeolocationInformations>> Post([FromBody] IEnumerable<string> values)
        {
            var ips = new List<IPAddress>();
            foreach (var value in values)
            {
                if (!IPAddress.TryParse(value, out var ip))
                    return BadRequest(value);

                ips.Add(ip);
            }

            var locations = _geolocalizationService.GetLocations(ips);
            if (locations.Count == 0)
                return NotFound(values);

            return Ok(locations);
        }
    }
}