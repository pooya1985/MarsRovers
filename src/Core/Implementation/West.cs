using System;
using MarsRovers.Core.Domain.Model;

namespace MarsRovers.Core.Implementation
{
    public class West:IHeading
    {
        public char Code { get { return Char.Parse(ToString()); } }

        public IHeading RotateLeft()
        {
            return new South();
        }

        public IHeading RotateRight()
        {
            return new North();
        }

        public void MovePositionAheadOf(Position position)
        {
            position.Spot.MoveWest();
        }

        public override string ToString()
        {
            return "W";
        }
    }
}