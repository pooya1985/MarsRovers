using MarsRovers.Core.Domain.Model;
using MarsRovers.Core.Domain.Services;

namespace MarsRovers.Core.Domain.Validation
{
    public class SouthBoundaryChecker : BaseChecker, IBoundaryChecker
    {
        public SouthBoundaryChecker(IPlateau plateau)
        {
            _plateau = plateau;
        }
        public bool IsValid(ISpot spot)
        {
            return spot.Y >= _plateau.SouthBoundary;
        }
    }
}