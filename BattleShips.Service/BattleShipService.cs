using BattleShip.Common.Const;
using BattleShip.Common.Enum;
using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Service
{
    public class BattleShipService : IBattleShipService
    {
        private Grid grid { get; set; }
        private List<Ship> ships = new List<Ship>();


        private Ship battleShip1;
        private Ship destroyer1;
        private Ship destroyer2;


        public BattleShipService() { }


        public Task<bool> CreateBattleShip(int boardSizeX, int boardSizeY)
        {
            grid = new Grid(boardSizeX, boardSizeY);

            List<GridLocation> ship1Locations = new List<GridLocation>()
            {
                new GridLocation("A",1),
                new GridLocation("A",2),
                new GridLocation("A",3),
                new GridLocation("A",4),
                new GridLocation("A",5),
            };
            List<GridLocation> destroyer1Locations = new List<GridLocation>()
            {
                new GridLocation("X",1),
                new GridLocation("X",2),
                new GridLocation("X",3),
                new GridLocation("X",4),
            };
            List<GridLocation> destroyer2Locations = new List<GridLocation>()
            {
                new GridLocation("y",1),
                new GridLocation("y",2),
                new GridLocation("y",3),
                new GridLocation("y",4),
            };

            battleShip1 = new Ship(ShipSize.BattleShipSize, ShipType.Battleship, ship1Locations);
            destroyer1 = new Ship(ShipSize.DestroyerSize, ShipType.Destroyers, destroyer1Locations);
            destroyer2 = new Ship(ShipSize.DestroyerSize, ShipType.Destroyers, destroyer2Locations);

            ships = new List<Ship>() { battleShip1, destroyer1, destroyer2 };
            return Task.FromResult(true);

        }

        public Task<bool> Fire(string locationX, int locationY)
        {
            var isSuccess = false;
            var battleShip = ships.Where(ship => ship.ShipType == ShipType.Battleship).FirstOrDefault();

            if (battleShip != null)
            {
                var target = new GridLocation(locationX, locationY);
                var battleShipGridLocations = battleShip.GridLocations;
                isSuccess = battleShipGridLocations.Any(location => location.X == target.X && location.Y == target.Y);

                if (isSuccess)
                {
                    UpdateShipHitCount(battleShip.Id);
                }
            }

            return Task.FromResult(isSuccess);
        }

        public Task<List<Ship>> GetBattleshipDetails()
        {
            return Task.FromResult(ships);
        }

        public Task<List<Ship>> GetSunkShipDetails()
        {
            var sunkShips = ships.Where(ship => ship.Size == ship.HitCount).ToList();
            return Task.FromResult(sunkShips);
        }

        private void UpdateShipHitCount(string shipId)
        {
            var ship = ships.Where(x => x.Id == shipId).FirstOrDefault();
            if (ship != null)
            {
                ship.HitCount = ship.HitCount + 1;
            }
        }
    }
}
