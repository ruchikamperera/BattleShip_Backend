
using BattleShip.Service;

namespace Battleship.Test
{
    public class BattleShipServiceTest
    {

        [Fact]
        public async void CreateBattleship_ReturnsExpectedData()
        {
            var service = new BattleShipService();

            // Act
            var result = await service.CreateBattleShip(10,10);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async void GetBattleshipDetails_ReturnsExpectedData()
        {   
               var service = new BattleShipService();

             // Act
               var result = await service.GetBattleshipDetails();

             // Assert
              Assert.NotNull(result);
        }

        [Fact]
        public async void Fire_ReturnsExpectedData()
        {
            var service = new BattleShipService();

            // Act
            var result = await service.Fire("A",1);

            // Assert
            Assert.True(result);
        }
    }
}