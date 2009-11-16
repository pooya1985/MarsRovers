using System;

namespace MarsRovers.Core
{
    public class East : Heading
    {
        private Plateau _plateau;

        public char Code { get { return Char.Parse(ToString()); } }

        public East(Plateau plateau)
        {
            _plateau = plateau;
        }
        public Heading RotateLeft()
        {
           return  new North(_plateau);
        }

        public Heading RotateRight()
        {
            return new South(_plateau);
        }

        public void MovePositionAhead(Position position)
        {
            position.Spot.MoveEast(_plateau);
        }

        
        public override string ToString()
        {
            return "E";
        }
    }
}