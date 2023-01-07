using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    public class Aggregator
    {
        public static void GenerateMaze(int sizeY, int sizeX, MazeCell userBeginCell, MazeCell userEndCell)
        {
            Field field = new Field(sizeY, sizeX, userBeginCell.Y, userBeginCell.X, userEndCell.Y, userEndCell.X);
            MazeCell[,] fieldArr = field.GenerateField();
            MazeGeneration generator = new MazeGeneration(userBeginCell.Y, userBeginCell.X, fieldArr);
            generator.ByPassField();
            field.Print();
        } 
    }
}
