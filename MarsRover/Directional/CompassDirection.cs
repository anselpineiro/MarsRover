using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Directional
{
    public class CompassDirection
    {


        private Char _directionValue;
        private CompassDirection _left;
        private CompassDirection _right;

        public Char DirectionValue { get { return _directionValue; } }

        public CompassDirection Left { get { return _left; }  }
        public CompassDirection Right { get { return _right; } }


        public CompassDirection(Char direction)
        {
            this._directionValue = direction;
        }
        

        public void setAdjacent(CompassDirection Left, CompassDirection Right)
        {
            this._left = Left;
            this._right = Right;
        }


    }
}
