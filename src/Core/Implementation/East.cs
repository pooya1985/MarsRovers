using System;
using MarsRovers.Core.Domain.Model;

namespace MarsRovers.Core.Implementation
{
    public class East : IHeading
    {
        public char Code { get { return Char.Parse(ToString()); } }

        public IHeading RotateLeft()
        {
            return  new North();
        }

        public IHeading RotateRight()
        {
            return new South();
        }

        public void MovePositionAheadOf(Position position)
        {
            position.Spot.MoveEast();
        }
        
        public override string ToString()
        {
            return "E";
        }
    }
}