using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    public struct MazeCell
    {
        public int X;
        public int Y;
        public bool visited;
        public int value;
        public MazeCell(int x, int y, int _value = 0)
        {
            X = x;
            Y = y;
            value = _value;
            visited = false;
        }
    }
}
