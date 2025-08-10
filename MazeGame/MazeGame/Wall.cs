using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MazeGame
{
    internal class Wall : IMazeObject
    {
        public char Icon { get { return '#'; } }
        public bool IsSolid { get { return true; } }
    }
}
