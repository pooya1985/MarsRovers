namespace MarsRovers.Core.Domain.Model
{
    public interface IHeading
    {
        char Code { get; }
        IHeading RotateLeft();
        IHeading RotateRight();


        void MovePositionAheadOf(Position position);
        
    }
}