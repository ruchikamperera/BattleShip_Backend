using BattleShip.Common.Enum;
using BattleShips.Models;

namespace BattleShips.Dtos
{
    public class ShipDto
    {
        public string Id { get; set; }
        public ShipType ShipType { get; set; }
        public List<GridLocationDto> GridLocations { get; set; }
        public int Size { get; set; }
        public int HitCount { get; set; }
    }
}
