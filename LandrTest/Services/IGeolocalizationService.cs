using LandrTest.Models;
using System.Collections.Generic;
using System.Net;

namespace LandrTest.Services
{
    public interface IGeolocalizationService
    {
        GeolocationInformations GetLocation(IPAddress ip);
        List<GeolocationInformations> GetLocations(IEnumerable<IPAddress> ips);
    }
}