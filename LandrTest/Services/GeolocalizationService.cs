using LandrTest.Models;
using MaxMind.GeoIP2;
using System.Collections.Generic;
using System.Net;
using System.Reflection;

namespace LandrTest.Services
{
    public class GeolocalizationService : IGeolocalizationService
    {
        private readonly DatabaseReader _databaseReader;

        public GeolocalizationService()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly.GetName().Name;
            var resource = assembly.GetManifestResourceStream($"{assemblyName}.Resources.GeoLite2-City.mmdb");

            _databaseReader = new DatabaseReader(resource);
        }

        public GeolocationInformations GetLocation(IPAddress ip)
        {
            if (!_databaseReader.TryCity(ip, out var city))
                return null;

            return new GeolocationInformations(ip, city.Country.Name, city.MostSpecificSubdivision.Name, city.City.Name, city.Location.Latitude, city.Location.Longitude);
        }

        public List<GeolocationInformations> GetLocations(IEnumerable<IPAddress> ips)
        {
            var locations = new List<GeolocationInformations>();

            foreach (var ip in ips)
                locations.Add(GetLocation(ip));

            return locations;
        }
    }
}