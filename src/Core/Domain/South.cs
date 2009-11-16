using System;

namespace MarsRovers.Core
{
    public class South : Heading
    {
        private Plateau _plateau;

        public char Code { get { return Char.Parse(ToString()); } }

        public South(Plateau plateau)
        {
            _plateau = plateau;
        }
        public Heading RotateLeft()
        {
            return new East(_plateau);
        }

        public Heading RotateRight()
        {
            return new West(_plateau);
        }

        public void MovePositionAhead(Position position)
        {
            position.Spot.MoveSouth(_plateau);
        }

        public override string ToString()
        {
            return "S";
        }
    }
}