using System;
using System.Collections.Generic;
using System.Text;
using MarsRover.Directional;

namespace MarsRover
{
    public class Rover
    {
        private Compass _compass;

        public Compass compass { get { return _compass; } }

        public GridCoordinate Coordinate { get; set; }
        public Char Z { get { return compass.DirectionValue; } }


        public Rover(GridCoordinate initialCoordinate, Char initialCompassDirection)
        {
            this.Coordinate = initialCoordinate;
            _compass = new Compass(initialCompassDirection);
            
        }


        public void SetPosition(GridCoordinate coordinate, Char direction)
        {
            this.Coordinate = coordinate;
            compass.SetDirection(direction);
        }

        public void TurnRight()
        {
            compass.TurnNeedle(NeedleTurn.RIGHT);
        }

        public void TurnLeft()
        {
            compass.TurnNeedle(NeedleTurn.LEFT);
        }



    }
}
