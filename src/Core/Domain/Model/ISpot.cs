namespace MarsRovers.Core.Domain.Model
{
    public interface ISpot
    {
        Coordinate X { get; }
        Coordinate Y { get; }

        void MoveNorth();
        void MoveSouth();
        void MoveEast();
        void MoveWest();
    }
}