using System;

namespace MarsRovers.Core
{
    public class PlateauSpot : Spot
    {
        private Coordinate _x;
        private Coordinate _y;
        private Plateau _plateau;

        public Coordinate X
        {
            get { return _x; }
        }

        public Coordinate Y
        {
            get { return _y; }
        }

        public PlateauSpot(Coordinate x, Coordinate y)
        {
            _x = x;
            _y = y;
        }


        public void MoveNorth(Plateau plateau)
        {
            if(!IsInNorthBoundaryOf(plateau))
                _y.Increment();
            else
            {
                throw new SpotOutsidePlateauException();
            }
        }

        public void MoveSouth(Plateau plateau)
        {
            if(!IsInSouthBoundaryOf(plateau))
                _y.Decrement();
            else
                throw new SpotOutsidePlateauException();
        }
        
        public void MoveEast(Plateau plateau)
        {
            if(!IsInEastBoundaryOf(plateau))
                _x.Increment();
            else
            {
                throw new SpotOutsidePlateauException();
            }
        }
        
        public void MoveWest(Plateau plateau)
        {
            if(!IsInWestBoundaryOf(plateau))
            {
                _x.Decrement();
            }
            else
            {
                throw new SpotOutsidePlateauException();
            }
        }

        public override string ToString()
        {
            return String.Format("{0} {1}",_x,_y);
        }



        private bool IsInNorthBoundaryOf(Plateau plateau)
        {
            return this._y.Equals(plateau.NorthBoundary);
        }

        private bool IsInSouthBoundaryOf(Plateau plateau)
        {
            return this._y.Equals(plateau.SouthBoundary);
        }

        private bool IsInEastBoundaryOf(Plateau plateau)
        {
            return this._x.Equals(plateau.EastBoundary);
        }

        private bool IsInWestBoundaryOf(Plateau plateau)
        {
            return this._x.Equals(plateau.WestBoundary);
        }
    }
}