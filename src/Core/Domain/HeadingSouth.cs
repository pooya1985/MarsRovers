using System;

namespace MarsRovers.Core
{
    public class HeadingSouth : IHeading
    {
        private IPlateau _plateau;

        public char Code { get { return Char.Parse(ToString()); } }

        public HeadingSouth(IPlateau plateau)
        {
            _plateau = plateau;
        }
        public IHeading RotateLeft()
        {
            return new HeadingEast(_plateau);
        }

        public IHeading RotateRight()
        {
            return new HeadingWest(_plateau);
        }

        public void Move(Coordinate coordinate)
        {
            if(!_plateau.IsInSouthBoundary(coordinate))
                coordinate.Y.Decrement();
        }

        public override string ToString()
        {
            return "S";
        }
    }
}