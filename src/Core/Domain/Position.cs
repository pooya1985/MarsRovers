using System;
using System.Collections;
using System.Collections.Generic;

namespace MarsRovers.Core
{
    public class Position : IEquatable<Position> , IComparable<Position> 
    {
        private int _position;

        public Position(int position)
        {
            _position = position;
        }

        public void Increment()
        {
            _position++;
        }

        public void Decrement()
        {
            _position--;
        }

        public static implicit operator int(Position position)
        {
            return position._position;
        }

        public static implicit operator Position(int position)
        {
            return new Position(position);
        }

        public bool Equals(Position other)
        {
            return _position == other;
        }

        public override string ToString()
        {
            return _position.ToString();
        }
        
        public int CompareTo(Position other)
        {
            if(_position > other)
            {
                return 1;
            }
            else if(_position == other)
            {
                return 0;
            }
            return -1; 
        }
    }
}