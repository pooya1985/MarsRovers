using System;
using System.Linq;

namespace MarsRovers.Core
{
    public class Rover : IRover
    {
        private IHeading _heading;
        private Coordinate _coordinate;
        private const char _BLANK = ' ';
        private IPlateau _plateau;
        
        public Rover(IPlateau plateau, Coordinate coordinate, IHeading heading)
        {
            _plateau = plateau;
            _coordinate = coordinate;
            _heading = heading;
        }

        public Coordinate Coordinate
        {
            get { return _coordinate; }
        }
        
        public void RotateRight()
        {
            _heading = _heading.RotateRight();
        }

        public void RotateLeft()
        {
            _heading = _heading.RotateLeft();
        }

        public void Move()
        {
            _coordinate.MoveAhead(_heading);
        }

        public override string ToString()
        {
            return String.Concat(Coordinate.ToString(), _BLANK, _heading.ToString());
        }
    }
}