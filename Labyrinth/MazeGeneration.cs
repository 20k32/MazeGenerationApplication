using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    public class MazeGeneration
    {
        private MazeCell nextCell;
        private MazeCell currentCell;
        private MazeCell[,] field;
        private int longitude;
        private int latitude;
        private Stack<MazeCell> cells;
        public MazeGeneration(int yPos, int xPos, MazeCell[,] _field)
        {
            currentCell.Y = yPos;
            currentCell.X = xPos;
            nextCell = currentCell;
            field = _field;
            longitude = field.GetLength(0);
            latitude = field.GetLength(1);
            cells = new Stack<MazeCell>();
        }
        public bool IsValid(int i, int j)
        {
            return i < longitude - 1 && j < latitude - 1 && i >= 1 && j >= 1 && field[i, j].value != 0 && field[i, j].visited != true;
        }

        public List<MazeCell> GetCellNeighbors(int i, int j)
        {
            List<MazeCell> neighbors = new List<MazeCell>();
            if (IsValid(i - 2, j))
            {
                neighbors.Add(field[i - 2, j]);
            }
            if (IsValid(i, j - 2))
            {
                neighbors.Add(field[i, j - 2]);
            }
            if (IsValid(i + 2, j))
            {
                neighbors.Add(field[i + 2, j]);
            }
            if (IsValid(i, j + 2))
            {
                neighbors.Add(field[i, j + 2]);
            }
          
            return neighbors;
        }
        public void RemoveWall(MazeCell current, MazeCell next)
        {
            int xDiff = next.X - current.X,
                yDiff = next.Y - current.Y,
                addX, addY, resultX, resultY;

            addX = (xDiff != 0) ? (xDiff / Math.Abs(xDiff)) : 0;
            addY = (yDiff != 0) ? (yDiff / Math.Abs(yDiff)) : 0;

            resultX = current.X + addX;
            resultY = current.Y + addY;

            field[resultY, resultX].visited = true;
            field[resultY, resultX].value = 1;
        }
        public void ByPassField()
        {
            Random random = new Random();
            List<MazeCell> neighbors = null;
            while (true)
            {
                neighbors = GetCellNeighbors(currentCell.Y, currentCell.X);
                if (neighbors.Count != 0)
                {
                    int indexer = random.Next(neighbors.Count);
                    nextCell = neighbors[indexer];
                    RemoveWall(currentCell, nextCell);
                    cells.Push(nextCell);
                    field[currentCell.Y, currentCell.X].visited = true;
                    currentCell = nextCell;
                }
                else if (cells.Count > 0)
                {
                    field[currentCell.Y, currentCell.X].visited = true;
                    currentCell = cells.Pop();
                }
                else
                    break;
            }
        }
    }
}
