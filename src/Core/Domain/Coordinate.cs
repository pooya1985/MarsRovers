using System;
using System.Collections;
using System.Collections.Generic;

namespace MarsRovers.Core
{
    public class Coordinate : IEquatable<Coordinate> , IComparable<Coordinate> 
    {
        private int _value;

        public Coordinate(int value)
        {
            _value = value;
        }

        public void Increment()
        {
            _value++;
        }

        public void Decrement()
        {
            _value--;
        }

        public static implicit operator int(Coordinate coordinate)
        {
            return coordinate._value;
        }

        public static implicit operator Coordinate(int position)
        {
            return new Coordinate(position);
        }

        public bool Equals(Coordinate other)
        {
            return _value == other;
        }

        public override string ToString()
        {
            return _value.ToString();
        }
        
        public int CompareTo(Coordinate other)
        {
            if(_value > other)
            {
                return 1;
            }
            else if(_value == other)
            {
                return 0;
            }
            return -1; 
        }
    }
}