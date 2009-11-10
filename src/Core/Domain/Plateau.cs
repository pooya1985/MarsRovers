using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRovers.Core
{
    public class Plateau : IPlateau
    {
        private IList<Coordinate> _grid;

        public Plateau(Coordinate coordinate)
        {
            BuildGrid(coordinate);
        }

        public int GetSize()
        {
            return _grid.Max(x => x.X) * _grid.Max(y => y.Y);
        }

        public Coordinate GetPosition(int x, int y)
        {
            return _grid.Where(s => s.X == x && s.Y == y).First();
        }
        
        private void BuildGrid(Coordinate maxCoordinate)
        {
            _grid = new List<Coordinate>();
            for (int _x = 0; _x <= maxCoordinate.X; _x++)
                for (int _y = 0; _y <= maxCoordinate.Y; _y++)
                    _grid.Add(new Coordinate(_x, _y));
        }

        public bool IsInNorthBoundary(Coordinate coordinate)
        {
            return (coordinate.Y.Equals(_grid.Max(p => p.Y)));
        }

        public bool IsInSouthBoundary(Coordinate coordinate)
        {
            return (coordinate.Y.Equals(_grid.Min(p => p.Y)));
        }

        public bool IsInEastBoundary(Coordinate coordinate)
        {
            return (coordinate.X.Equals(_grid.Max(p => p.X)));
        }

        public bool IsInWestBoundary(Coordinate coordinate)
        {
            return (coordinate.X.Equals(_grid.Min(p => p.X)));
        }
        
    }
}