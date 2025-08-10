using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    //create symbol of Player '@'
    internal class Player : IMazeObject
    {

        public char Icon { get { return '@'; } }
        public bool IsSolid { get { return false; } }

        //the start position of the player
        public int X { get; set; }
        public int Y { get; set; }
    }
}
