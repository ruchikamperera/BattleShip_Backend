using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShips.Models
{
    public class GridLocation
    {
        public GridLocation(string x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public string X {  get; set; }
        public int Y { get; set; }
    }
}
