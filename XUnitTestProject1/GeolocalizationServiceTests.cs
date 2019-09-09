using LandrTest.Services;
using System.Collections.Generic;
using System.Net;
using Xunit;

namespace XUnitTestProject1
{
    public class GeolocalizationServiceTests
    {
        private readonly GeolocalizationService _service;

        public GeolocalizationServiceTests()
        {
            _service = new GeolocalizationService();
        }

        [Fact]
        public void GetLocationTest_Success()
        {
            // Arrange
            var ip = IPAddress.Parse("107.159.19.143");

            // Act
            var result = _service.GetLocation(ip);

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public void GetLocationTest_Fail1()
        {
            // Arrange
            var ip = IPAddress.Parse("192.168.0.1");

            // Act
            var result = _service.GetLocation(ip);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetLocationTest_Fail2()
        {
            // Arrange
            var ip = IPAddress.Parse("::1");

            // Act
            var result = _service.GetLocation(ip);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetLocationTest_Fail3()
        {
            // Arrange
            var ip = IPAddress.Parse("::ffff:172.17.0.1");

            // Act
            var result = _service.GetLocation(ip);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetLocationsTest_Success()
        {
            // Arrange
            var ips = new List<IPAddress>()
            {
                IPAddress.Parse("107.159.19.143"),
                IPAddress.Parse("107.159.20.143"),
                IPAddress.Parse("107.160.20.143"),
            };

            // Act
            var result = _service.GetLocations(ips);

            // Assert
            Assert.NotNull(result);
            Assert.All(result, x => Assert.NotNull(x));
        }

        [Fact]
        public void GetLocationsTest_PartialSuccess()
        {
            // Arrange
            var ips = new List<IPAddress>()
            {
                IPAddress.Parse("192.168.0.1"),
                IPAddress.Parse("107.159.20.143"),
                IPAddress.Parse("107.160.20.143"),
            };

            // Act
            var result = _service.GetLocations(ips);

            // Assert
            Assert.NotNull(result);
            Assert.Contains(null, result);
        }

        [Fact]
        public void GetLocationsTest_NoResult()
        {
            // Arrange
            var ips = new List<IPAddress>();

            // Act
            var result = _service.GetLocations(ips);

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
        }
    }
}