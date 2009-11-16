namespace MarsRovers.Core
{
    public interface Vehicle
    {
        Position Position { get; }
        void RotateRight();
        void RotateLeft();
        void Move();
    }
}