using System;
using System.Linq;

namespace MarsRovers.Core
{
    public class Rover
    {
        private Direction _direction;
        private Position _position;
        private const char _BLANK = ' ';
        private IPlateau _plateau;
        
        private Direction[] _directions = new Direction[4]
                                              {
                                                  new Direction('N', 'W', 'E'),
                                                  new Direction('E', 'N', 'S'),
                                                  new Direction('S', 'E', 'W'),
                                                  new Direction('W', 'S', 'N')
                                              };

        public Rover(IPlateau plateau, Position position, char heading)
        {
            _plateau = plateau;
            _position = position;
            _direction = _directions.First(d => d.Heading == heading);
        }

        public Position Position
        {
            get { return _position; }
        }
        
        public void RotateRight()
        {
            _direction = _directions.First(d => d.Heading == _direction.Right);
        }

        public void RotateLeft()
        {
            _direction = _directions.First(d => d.Heading == _direction.Left);
        }

        public void Move()
        {
            _position = GetTargetPosition();
        }

        public override string ToString()
        {
            return String.Concat(Position.ToString(), _BLANK, _direction.Heading);
        }

        /*
         * To ensure that the target position is always a valid one, the rover asks the plateau the position to where
         * it wants to move. That prevents the rover to move to an unkown position.
         * I introduced this check because we don't wanna loose our Rovers in Mars, do we? :) 
         */
        
        private Position GetTargetPosition()
        {
            switch (_direction.Heading)
            {
                case 'N':
                    return _plateau.GetPositionNorthOf(Position);
                case 'S':
                    return _plateau.GetPositionSouthOf(Position);
                case 'E':
                    return _plateau.GetPositionEastOf(Position);
                case 'W':
                    return _plateau.GetPositionWestOf(Position);
            }
            return this.Position;
        }

        

    }
}