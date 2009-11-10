namespace MarsRovers.Core
{
    public interface IPlateau
    {
        int GetSize();
        Position GetPosition(int x, int y);
        Position GetPositionNorthOf(Position position);
        Position GetPositionEastOf(Position position);
        Position GetPositionSouthOf(Position position);
        Position GetPositionWestOf(Position position);

    }
}