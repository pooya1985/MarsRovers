namespace MarsRovers.Core
{
    public interface IRover
    {
        Coordinate Coordinate { get; }
        void RotateRight();
        void RotateLeft();
        void Move();
    }
}