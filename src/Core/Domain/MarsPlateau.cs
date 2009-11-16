using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRovers.Core
{
    public class MarsPlateau : Plateau
    {
        private IList<Spot> _grid;

        public Coordinate NorthBoundary
        {
            get { return _grid.Max(s => s.Y); }
        }

        public Coordinate SouthBoundary
        {
            get { return _grid.Min(s => s.Y); }
        }

        public Coordinate EastBoundary
        {
            get { return _grid.Max(s => s.X); }
        }

        public Coordinate WestBoundary
        {
            get { return _grid.Min(s => s.X); }
        }


        public MarsPlateau(Spot spot)
        {
            BuildGrid(spot);
        }

        public int GetSize()
        {
            return _grid.Max(x => x.X) * _grid.Max(y => y.Y);
        }

        public Spot GetSpot(int x, int y)
        {
            return _grid.Where(s => s.X == x && s.Y == y).First();
        }

        private void BuildGrid(Spot maxPosition)
        {
            _grid = new List<Spot>();
            for (int _x = 0; _x <= maxPosition.X; _x++)
                for (int _y = 0; _y <= maxPosition.Y; _y++)
                    _grid.Add(new PlateauSpot(_x, _y));
        }
    }
}