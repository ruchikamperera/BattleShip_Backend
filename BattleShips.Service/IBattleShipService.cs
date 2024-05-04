using BattleShips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Service
{
    public interface IBattleShipService
    {
        Task<bool> CreateBattleShip(int boardSizeX, int boardSizeY);
        Task<bool> Fire(string locationX, int locationY);
        Task<List<Ship>> GetBattleshipDetails();
        Task<List<Ship>> GetSunkShipDetails();

    }
}
