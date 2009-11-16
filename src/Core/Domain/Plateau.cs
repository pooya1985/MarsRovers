namespace MarsRovers.Core
{
    public interface Plateau
    {
        int GetSize();
        Spot GetSpot(int x, int y);
        Coordinate WestBoundary { get; }
        Coordinate NorthBoundary { get; }
        Coordinate SouthBoundary { get; }
        Coordinate EastBoundary { get; }
    }
}