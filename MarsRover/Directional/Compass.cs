using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MarsRover.Directional
{
    public class Compass
    {

        private Dictionary<Char, CompassDirection> compassDictionary;
        private CompassDirection _direction;

        public Char DirectionValue { get { return _direction.DirectionValue; } }


        public Compass(Char initialPosition)
        {
            compassDictionary = new Dictionary<Char, CompassDirection>();

            compassDictionary.Add('N', new CompassDirection('N'));
            compassDictionary.Add('E', new CompassDirection('E'));
            compassDictionary.Add('S', new CompassDirection('S'));
            compassDictionary.Add('W', new CompassDirection('W'));

            compassDictionary['N'].setAdjacent(compassDictionary['W'], compassDictionary['E']);
            compassDictionary['E'].setAdjacent(compassDictionary['N'], compassDictionary['S']);
            compassDictionary['S'].setAdjacent(compassDictionary['E'], compassDictionary['W']);
            compassDictionary['W'].setAdjacent(compassDictionary['S'], compassDictionary['N']);

            this._direction = compassDictionary[initialPosition];

        }


        public void TurnNeedle(NeedleTurn needleTurn)
        {
            if (needleTurn == NeedleTurn.RIGHT)
                _direction = _direction.Right;
            else 
                _direction = _direction.Left;

        }

        public void SetDirection(Char direction)
        {
            this._direction = compassDictionary[direction];
        }

    }
}
