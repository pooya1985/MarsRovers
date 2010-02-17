using MarsRovers.Core.Domain.Model;

namespace MarsRovers.Core.Implementation
{
    public class MarsPlateau : IPlateau
    {
        private Coordinate max_x;
        private Coordinate max_y;

        public Coordinate NorthBoundary
        {
            get { return max_y; }
        }

        public Coordinate SouthBoundary
        {
            get { return 0; }
        }

        public Coordinate EastBoundary
        {
            get { return max_x; }
        }

        public Coordinate WestBoundary
        {
            get { return 0; }
        }


        public MarsPlateau(Coordinate x, Coordinate y)
        {
            max_x = x;
            max_y = y;
        }

        public int GetSize()
        {
            return max_x * max_y;
        }
    }
}