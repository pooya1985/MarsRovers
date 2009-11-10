namespace MarsRovers.Core
{
    public interface IPlateau
    {
        int GetSize();
        Coordinate GetPosition(int x, int y);
        bool IsInNorthBoundary(Coordinate coordinate);
        bool IsInSouthBoundary(Coordinate coordinate);
        bool IsInEastBoundary(Coordinate coordinate);
        bool IsInWestBoundary(Coordinate coordinate);

    }
}