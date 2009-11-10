using System;

namespace MarsRovers.Core
{
 
    public class HeadingNorth : IHeading
    {
        private readonly IPlateau _plateau;

        public char Code { get { return Char.Parse(ToString()); } }
        
        public HeadingNorth(IPlateau plateau)
        {
            _plateau = plateau;
        }
        public IHeading RotateLeft()
        {
            return new HeadingWest(_plateau);
        }

        public IHeading RotateRight()
        {
            return new HeadingEast(_plateau);
        }

        public void Move(Coordinate coordinate)
        {
            if(!_plateau.IsInNorthBoundary(coordinate))
                coordinate.Y.Increment();

        }

        public override string ToString()
        {
            return "N";
        }
    }
}