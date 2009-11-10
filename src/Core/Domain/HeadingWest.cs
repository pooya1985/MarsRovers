using System;

namespace MarsRovers.Core
{
    public class HeadingWest:IHeading
    {
        public IPlateau _plateau;

        public char Code { get { return Char.Parse(ToString()); } }

        public HeadingWest(IPlateau plateau)
        {
            _plateau = plateau;
        }
        public IHeading RotateLeft()
        {
            return new HeadingSouth(_plateau);
        }

        public IHeading RotateRight()
        {
            return new HeadingNorth(_plateau);
        }

        public void Move(Coordinate coordinate)
        {
            if(!_plateau.IsInWestBoundary(coordinate))
                coordinate.X.Decrement();
        }

        public override string ToString()
        {
            return "W";
        }
    }
}