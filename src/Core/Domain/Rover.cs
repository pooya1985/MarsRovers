using System;
using System.Linq;

namespace MarsRovers.Core
{
    public class Rover : Vehicle
    {
        private Position _position;
        
        public Rover(Position position)
        {
                _position = position;
        }

        public Position Position
        {
            get { return _position; }
        }
        
        public void RotateRight()
        {
            _position.RotateRight();
        }

        public void RotateLeft()
        {
            _position.RotateLeft();
        }

        public void Move()
        {
            _position.Increment();
        }

        public override string ToString()
        {
            return Position.ToString();
        }
    }
}