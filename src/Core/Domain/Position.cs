using System;

namespace MarsRovers.Core
{
    public class Position
    {
        private Spot _spot;
        private Heading _heading;
        
        public Spot Spot
        {
            get { return _spot; }
            set { _spot = value; }
        }

        public Position(Spot spot, Heading heading)
        {
            Spot = spot;
            _heading = heading;
        }

        public void Increment()
        {
            _heading.MovePositionAhead(this);
        }
        
        public void RotateLeft()
        {
            _heading = _heading.RotateLeft();
        }

        public void RotateRight()
        {
            _heading = _heading.RotateRight();
        }

        public override string ToString()
        {
            return string.Format("{0} {1}",Spot,_heading);
        }
    }
}