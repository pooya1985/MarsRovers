namespace MarsRovers.Core
{
    public interface Spot
    {
        Coordinate X { get; }
        Coordinate Y { get; }

        void MoveNorth(Plateau plateau);
        void MoveSouth(Plateau plateau);
        void MoveEast(Plateau plateau);
        void MoveWest(Plateau plateau);
    }
}