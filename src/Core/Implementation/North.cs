using System;
using MarsRovers.Core.Domain.Model;

namespace MarsRovers.Core.Implementation
{
    public class North : IHeading
    {
        
        public char Code { get { return Char.Parse(ToString()); } }
        
        public IHeading RotateLeft()
        {
            return new West();
        }

        public IHeading RotateRight()
        {
            return new East();
        }

        public void MovePositionAheadOf(Position position)
        {
            position.Spot.MoveNorth();
        }

        public override string ToString()
        {
            return "N";
        }
    }
}