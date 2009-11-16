using System;

namespace MarsRovers.Core
{
 
    public class North : Heading
    {
        private readonly Plateau _plateau;

        public char Code { get { return Char.Parse(ToString()); } }
        
        public North(Plateau plateau)
        {
            _plateau = plateau;
        }
        public Heading RotateLeft()
        {
            return new West(_plateau);
        }

        public Heading RotateRight()
        {
            return new East(_plateau);
        }

        public void MovePositionAhead(Position position)
        {
            position.Spot.MoveNorth(_plateau);
        }

        public override string ToString()
        {
            return "N";
        }
    }
}