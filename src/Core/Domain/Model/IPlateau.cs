namespace MarsRovers.Core.Domain.Model
{
    public interface IPlateau
    {
        int GetSize();
        Coordinate WestBoundary { get; }
        Coordinate NorthBoundary { get; }
        Coordinate SouthBoundary { get; }
        Coordinate EastBoundary { get; }
    }
}