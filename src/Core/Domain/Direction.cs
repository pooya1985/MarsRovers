namespace MarsRovers.Core
{
    public struct Direction
    {
        private readonly char _heading;
        private readonly char _left;
        private readonly char _right;

        public Direction(char heading, char left, char right)
        {
            _heading = heading;
            _left = left;
            _right = right;
        }

        public char Heading
        {
            get { return _heading; }
        }

        public char Left
        {
            get { return _left; }
        }

        public char Right
        {
            get { return _right; }
        }
    }
}