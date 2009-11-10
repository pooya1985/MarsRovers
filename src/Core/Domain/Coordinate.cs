namespace MarsRovers.Core
{
    public class Coordinate
    {
        private Position _x;
        private Position _y;
        
        public Position X
        {
            get { return _x; }
            set { _x = value; }
        }

        public Position Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public Coordinate(int x, int y)
        {
            _x = x;
            _y = y;
        }

        public void MoveAhead(IHeading heading)
        {
            heading.Move(this);
        }

        public override string ToString()
        {
            return string.Concat(_x.ToString(), " ", _y.ToString());
        }
    }
}