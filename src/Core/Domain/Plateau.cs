using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRovers.Core
{
    public class Plateau : IPlateau
    {
        private IList<Position> _grid;

        public Plateau(Position position)
        {
            BuildGrid(position);
        }

        public int GetSize()
        {
            return _grid.Max(x => x.X) * _grid.Max(y => y.Y);
        }

        public Position GetPosition(int x, int y)
        {
            return _grid.Where(s => s.X == x && s.Y == y).First();
        }


        /* 
            The GetPositions Methods are used to inform a rover to what position 
            it should move. To ensure that the rover stays always within plateau's boudaries
            if the rover asks for a position outside of the plateu, rover's actual position is returned, 
            i.e. the rover doesn't move. 
         */

        public Position GetPositionNorthOf(Position position)
        {
            if (IsInNorthBoundary(position))
                return position;
            return GetPosition(position.X, position.Y + 1);
        }

        public Position GetPositionEastOf(Position position)
        {
            if (IsInEastBoundary(position))
                return position;
            return GetPosition(position.X + 1, position.Y);
        }

        public Position GetPositionSouthOf(Position position)
        {
            if (IsInSouthBoundary(position))
                return position;
            return GetPosition(position.X, position.Y - 1);
        }

        public Position GetPositionWestOf(Position position)
        {
            if (IsInWestBoundary(position))
                return position;
            return GetPosition(position.X - 1, position.Y);
        }

        private void BuildGrid(Position maxPosition)
        {
            _grid = new List<Position>();
            for (int _x = 0; _x <= maxPosition.X; _x++)
                for (int _y = 0; _y <= maxPosition.Y; _y++)
                    _grid.Add(new Position(_x, _y));
        }


        private bool IsInNorthBoundary(Position position)
        {
            return (position.Y == _grid.Max(p => p.Y));
        }

        private bool IsInSouthBoundary(Position position)
        {
            return (position.Y == _grid.Min(p => p.Y));
        }

        private bool IsInEastBoundary(Position position)
        {
            return (position.X == _grid.Max(p => p.X));
        }

        private bool IsInWestBoundary(Position position)
        {
            return (position.X == _grid.Min(p => p.X));
        }
        
    }
}