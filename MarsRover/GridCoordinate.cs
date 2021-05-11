using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover
{
    public class GridCoordinate
    {
        public int X { get; set; }
        public int Y { get; set; }

        public GridCoordinate(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
