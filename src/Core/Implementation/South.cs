using System;
using MarsRovers.Core.Domain.Model;

namespace MarsRovers.Core.Implementation
{
    public class South : IHeading
    {
        public char Code { get { return Char.Parse(ToString()); } }

        public IHeading RotateLeft()
        {
            return new East();
        }

        public IHeading RotateRight()
        {
            return new West();
        }

        public void MovePositionAheadOf(Position position)
        {
            position.Spot.MoveSouth();
        }

        public override string ToString()
        {
            return "S";
        }
    }
}