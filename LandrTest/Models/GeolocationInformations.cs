using System.Net;

namespace LandrTest.Models
{
    public class GeolocationInformations
    {
        public string IpAddress;
        public string Country;
        public string State;
        public string City;
        public double? Latitude;
        public double? Longitude;

        public GeolocationInformations(IPAddress ipAddress, string country, string state, string city, double? latitude, double? longitude)
        {
            IpAddress = ipAddress.ToString();
            Country = country;
            State = state;
            City = city;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}