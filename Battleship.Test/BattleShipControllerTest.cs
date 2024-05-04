
using AutoMapper;
using BattleShip.Service;
using BattleShips.Controllers;
using BattleShips.Dtos;
using BattleShips.Models;
using Moq;

namespace Battleship.Test
{
    public class BattleShipControllerTest
    {

        [Fact]
        public async void GetBattleshipDetails_ReturnsExpectedData()
        {
            // Arrange
            var mockService= new Mock<IBattleShipService>();
            var mapperMock = new Mock<IMapper>();
            var mapper = mapperMock.Object;
            var mockReturnList = new List<Ship>();
             mockService.Setup( service => service.GetBattleshipDetails()).ReturnsAsync(mockReturnList);
            var controller = new BattleShipController(mockService.Object , mapper);

            // Act
            var result = controller.GetBattleshipDetails();

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void Fire_ReturnsExpectedData()
        {
            // Arrange
            var mockService = new Mock<IBattleShipService>();
            var mapperMock = new Mock<IMapper>();
            var mapper = mapperMock.Object;
            mockService.Setup(service => service.Fire("x",0)).ReturnsAsync(true);
            var controller = new BattleShipController(mockService.Object, mapper);

            // Act
            var request = new GridLocationDto
            {
                X = "x",
                Y = 0
            };

            var result = controller.Fire(request).Result;

            // Assert
            Assert.NotNull(result);
        }

        [Fact]
        public async void CreateBattleShip_ReturnsExpectedData()
        {
            // Arrange
            var mockService = new Mock<IBattleShipService>();
            var mapperMock = new Mock<IMapper>();
            var mapper = mapperMock.Object;
            var mockReturnList = new List<Ship>();
            mockService.Setup(service => service.CreateBattleShip(10,10)).ReturnsAsync(true);
            var controller = new BattleShipController(mockService.Object, mapper);

            // Act
            var request = new GridDto
            {
                SizeX = 10,
                SizeY = 10
            };
            var result =  controller.CreateBattleShip(request);

            // Assert
            Assert.NotNull(result);
        }
    }
}