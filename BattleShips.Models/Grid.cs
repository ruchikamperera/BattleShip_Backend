using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Models
{
    public class Grid : BaseModel
    {
        public Grid(int sizeX,int sizeY) { 
            SizeX = sizeX;
            SizeY = sizeY;
        }
        public int SizeX { get; set; } = 0;
        public int SizeY { get; set; } = 0;
    }
}
