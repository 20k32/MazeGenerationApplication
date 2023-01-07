using System.Globalization;
using System.Net.Http.Headers;

namespace Labyrinth
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Aggregator.GenerateMaze(19, Console.WindowWidth - 11, new MazeCell(15,7), new MazeCell(Console.WindowWidth - 13, 17));
        }
    }
}