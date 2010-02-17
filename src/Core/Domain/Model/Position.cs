namespace MarsRovers.Core.Domain.Model
{
    public class Position
    {
        private ISpot _spot;
        private IHeading _heading;
        
        public ISpot Spot
        {
            get { return _spot; }
            set { _spot = value; }
        }

        public IHeading Heading { get { return _heading; } }
        public Position(ISpot spot, IHeading heading)
        {
            Spot = spot;
            _heading = heading;
        }

        public void Increment()
        {
            _heading.MovePositionAheadOf(this);
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