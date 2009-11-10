using System;

namespace MarsRovers.Core
{
    public class HeadingEast : IHeading
    {
        private IPlateau _plateau;

        public char Code { get { return Char.Parse(ToString()); } }

        public HeadingEast(IPlateau plateau)
        {
            _plateau = plateau;
        }
        public IHeading RotateLeft()
        {
           return  new HeadingNorth(_plateau);
        }

        public IHeading RotateRight()
        {
            return new HeadingSouth(_plateau);
        }

        public void Move(Coordinate coordinate)
        {
            if(!_plateau.IsInEastBoundary(coordinate))
                coordinate.X.Increment();
        }

        
        public override string ToString()
        {
            return "E";
        }
    }
}