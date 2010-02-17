using MarsRovers.Core.Domain.Model;
using MarsRovers.Core.Domain.Services;

namespace MarsRovers.Core.Domain.Validation
{
    public class WestBoundaryChecker : BaseChecker, IBoundaryChecker
    {
        public WestBoundaryChecker(IPlateau plateau)
        {
            _plateau = plateau;
        }
        public bool IsValid(ISpot spot)
        {
            return spot.X >= _plateau.WestBoundary;
        }
    }
}