using MarsRovers.Core.Domain.Model;

namespace MarsRovers.Core.Domain.Services
{
    public interface IBoundaryChecker
    {
        bool IsValid(ISpot spot);
    }
}