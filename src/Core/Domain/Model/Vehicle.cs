using MarsRovers.Core.Services;

namespace MarsRovers.Core.Domain.Model
{
    public interface Vehicle
    {
        Position Position { get; }
        void ExecuteCommands(ICommand[] commands);
    }
}