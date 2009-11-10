namespace MarsRovers.Core
{
    public interface IHeading
    {
        char Code { get; }
        IHeading RotateLeft();
        IHeading RotateRight();


        void Move(Coordinate coordinate);
        
    }
}