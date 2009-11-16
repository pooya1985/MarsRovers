namespace MarsRovers.Core
{
    public interface Heading
    {
        char Code { get; }
        Heading RotateLeft();
        Heading RotateRight();


        void MovePositionAhead(Position position);
        
    }
}