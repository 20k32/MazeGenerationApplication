using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    public sealed class WallsPaths
    {
        public readonly char Name;
        public readonly int value;

        public readonly WallsPaths WALLS;
        public readonly WallsPaths PATHS;
        public readonly WallsPaths BEGIN;
        public readonly WallsPaths END;
        private WallsPaths()
        {
            WALLS = new WallsPaths('█', 0);
            PATHS = new WallsPaths(' ', 1);
            BEGIN = new WallsPaths('▓', 2);
            END = new WallsPaths('У', 3);
        }
        private WallsPaths(char name, int value)
        {
            Name = name;
            this.value = value;
        }
        public static WallsPaths GetInstance()
        {
            return WPInstanse.instance;
        }
        private class WPInstanse
        {
            static WPInstanse() { }
            internal static readonly WallsPaths instance = new WallsPaths();
        }
    }
}
