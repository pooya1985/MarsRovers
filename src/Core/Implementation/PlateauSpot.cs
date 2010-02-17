using System;
using MarsRovers.Core.Domain.Model;

namespace MarsRovers.Core.Implementation
{
    public class PlateauSpot : ISpot
    {
        private Coordinate _x;
        private Coordinate _y;
        
        public Coordinate X { get { return _x; } }

        public Coordinate Y { get { return _y; } }

        public PlateauSpot(Coordinate x, Coordinate y)
        {
            _x = x;
            _y = y;
        }

        public void MoveNorth()
        {
            Y.Increment();
        }

        public void MoveSouth()
        {
            Y.Decrement();
        }

        public void MoveEast()
        {
            X.Increment();
        }

        public void MoveWest()
        {
            X.Decrement();
        }

        public override string ToString()
        {
            return String.Format("{0} {1}", _x, _y);
        }
    }
}