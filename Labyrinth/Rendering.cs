using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Labyrinth
{
    public sealed class Field
    {
        private const int LONGITUDE_CONSTRAINT = 4;
        private const int LATITUDE_CONSTRAINT = 4;
        private int _longitude;
        public int Longitude
        {
            get => _longitude;
            private set
            {
                if (value < LONGITUDE_CONSTRAINT)
                {
                    throw new Exception($"Longitude cannot be less than {LONGITUDE_CONSTRAINT}");
                }
                _longitude = value;
            }
        }
        private int _latitude;
        public int Latitude
        { 
            get => _latitude;
            private set
            {
                if (value < LATITUDE_CONSTRAINT)
                {
                    throw new Exception($"Latitude cannot be less than {LATITUDE_CONSTRAINT}");
                }
                _latitude = value;
            }
        }
        private MazeCell[,] field;
        private WallsPaths wallsPaths;
        private int userPointX;
        private int userPointY;
        private int endPointX;
        private int endPointY;
        public Field(int longitude, int latitude, int _userPointX, int _userPointY, int _endPointX, int _endPointY)
        {
            Longitude = longitude;
            Latitude = latitude;
            wallsPaths = WallsPaths.GetInstance();
            userPointX = _userPointX;
            userPointY = _userPointY;
            endPointX = _endPointX;
            endPointY = _endPointY;
        }

        public MazeCell[,] GenerateField(int longitude, int latitude)
        {
            field = new MazeCell[longitude, latitude];
            return field;
        }
        public MazeCell[,] GenerateField()
        {
            field = new MazeCell[Longitude, Latitude];
            for (int i = 0; i < Longitude; i++)
            {
                for (int j = 0; j < Latitude; j++)
                {
                    if ((i % 2 != 0 && j % 2 != 0) && (i < Longitude - 1 && j < Latitude - 1))
                    {
                        if (i == userPointX && j == userPointY)
                            field[i, j].value = wallsPaths.BEGIN.value;
                        else if (i == endPointX && j == endPointY)
                            field[i, j].value = wallsPaths.END.value;
                        else
                            field[i, j].value = wallsPaths.PATHS.value;
                    }
                    else
                        field[i, j].value = wallsPaths.WALLS.value;

                    field[i, j].Y = i;
                    field[i, j].X = j;
                }
            }
            return field;
        }
        public char[,] InterpretField()
        {
            if (field == null)
                return null;

            char[,] result = new char[Longitude, Latitude];
            for (int i = 0; i < Longitude; i++)
            {
                for (int j = 0;  j < Latitude; j++)
                {
                    switch (field[i, j].value)
                    {
                        case 0: 
                            result[i, j] = wallsPaths.WALLS.Name; 
                            break;
                        case 1:
                            result[i, j] = wallsPaths.PATHS.Name;
                            break;
                        case 2:
                            result[i, j] = wallsPaths.BEGIN.Name;
                            break;
                        case 3:
                            result[i, j] = wallsPaths.END.Name;
                            break;
                    }
                }
            }
            return result;
        }
        public void Print()
        {

            char[,] arrayToPrint = InterpretField();
            int longitude = arrayToPrint.GetLength(0),
                latitude = arrayToPrint.GetLength(1);

            for (int i = 0; i < longitude; i++)
            {
                for (int j = 0; j < latitude; j++)
                {
                    if (field[i, j].visited == false)
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                    if (i == userPointX && j == userPointY)
                        Console.ForegroundColor = ConsoleColor.Green;
                    if (i == endPointX && j == endPointY)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                    }
                    Console.Write(arrayToPrint[i, j]);
                }
                Console.WriteLine();
            }
            Console.ResetColor();
        }
    }
}
