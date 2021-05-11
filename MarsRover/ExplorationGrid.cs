using MarsRover.Directional;
using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class ExplorationGrid
    {
        private GridCoordinate[,] CoordinateMap;
        private Rover rover;

        public ExplorationGrid(int xBounds, int yBounds)
        {
            CoordinateMap = new GridCoordinate[ xBounds + 1, yBounds + 1];
            rover = new Rover(new GridCoordinate(0, 0), 'N');

            PopulateCoordinateMap();
        }

        private void PopulateCoordinateMap()
        {
            for(int i = 0; i < CoordinateMap.GetLength(0); i++)
            {
                for (int j = 0; j < CoordinateMap.GetLength(1); j++)
                {
                    CoordinateMap[i, j] = new GridCoordinate(i, j);
                }
            }
        }



        public bool ConfirmPosition(int X, int Y, Char Z)
        {
            if (X >= CoordinateMap.GetLength(0) || Y >= CoordinateMap.GetLength(1))
                return false;
            
            rover.SetPosition(GetGridCoordinate(X, Y), Z);

            return true;
        }


        public string GetRoverPosition()
        {
            return String.Format("{0} {1} {2}", rover.Coordinate.X, rover.Coordinate.Y, rover.Z);
        }

        private GridCoordinate GetGridCoordinate(int X, int Y)
        {

            return CoordinateMap[X, Y];
        }


        public bool PerformInstruction(RoverInstruction instruction)
        {
            switch(instruction)
            {
                case RoverInstruction.R:
                    rover.TurnRight();
                    break;
                case RoverInstruction.L:
                    rover.TurnLeft();
                    break;
                case RoverInstruction.M:
                    return MoveRover();                    
            }
            return true;
        }

        private bool MoveRover()
        {
            Char direction = rover.compass.DirectionValue;

            if (direction == 'N' || direction == 'S')
                return MoveY(direction);
            else
                return MoveX(direction);

        }

        private bool MoveX(Char direction)
        {
            int X = rover.Coordinate.X + (direction == 'E' ? 1 : -1);

            if (X < 0)
                return false;

            rover.Coordinate = CoordinateMap[X, rover.Coordinate.Y];

            return true;
        }

        private bool MoveY(Char direction)
        {
            int Y = rover.Coordinate.Y + (direction == 'N' ? 1 : -1);

            if (Y < 0)
                return false;

            rover.Coordinate = CoordinateMap[rover.Coordinate.X, Y];

            return true;
        }


    }
}
