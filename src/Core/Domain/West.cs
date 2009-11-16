using System;

namespace MarsRovers.Core
{
    public class West:Heading
    {
        public Plateau _plateau;

        public char Code { get { return Char.Parse(ToString()); } }

        public West(Plateau plateau)
        {
            _plateau = plateau;
        }
        public Heading RotateLeft()
        {
            return new South(_plateau);
        }

        public Heading RotateRight()
        {
            return new North(_plateau);
        }

        public void MovePositionAhead(Position position)
        {
            position.Spot.MoveWest(_plateau );
        }

        public override string ToString()
        {
            return "W";
        }
    }
}