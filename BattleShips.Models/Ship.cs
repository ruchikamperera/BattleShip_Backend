using BattleShip.Common.Enum;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Models
{
    public class Ship : BaseModel
    {
        public Ship( int size, ShipType shipType, List<GridLocation> gridLocations) {
            this.Id = Guid.NewGuid().ToString();
            this.ShipType = shipType;
            this.GridLocations = gridLocations;
            this.Size = size;
        }

        public ShipType ShipType { get; set; }
        public List<GridLocation> GridLocations { get; set; }
        public int Size {get;set;}
        public int HitCount { get; set; }
    }
}
