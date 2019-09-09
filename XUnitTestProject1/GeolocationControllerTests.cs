using LandrTest.Controllers;
using LandrTest.Models;
using LandrTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Net;

namespace XUnitTestProject1
{
    public class GeolocationControllerTests
    {
        private readonly Mock<IGeolocalizationService> _service;
        private readonly GeolocationController _controller;

        public GeolocationControllerTests()
        {
            // TODO(emile): Mock Request.HttpContext.Connection.RemoteIpAddress
            var data = new GeolocationInformations(IPAddress.Parse("192.168.0.1"), "Canada", "Quebec", "Montreal", null, null);
            _service = new Mock<IGeolocalizationService>();
            _service.Setup(x => x.GetLocation(null)).Returns(data);
            _service.Setup(x => x.GetLocation(It.IsAny<IPAddress>())).Returns(data);
            _controller = new GeolocationController(_service.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext()
                }
            };
        }

        //[Fact]
        //public void Get_Success()
        //{
        //    // Arrange

        //    // Act
        //    var result = _controller.Get();

        //    // Assert
        //    Assert.Equal("Montreal", result.Value.City);
        //}
    }
}