using MarsRovers.Core.Domain.Model;
using MarsRovers.Core.Domain.Services;

namespace MarsRovers.Core.Domain.Validation
{
    public class EastBoundaryChecker : BaseChecker, IBoundaryChecker
    {
        public EastBoundaryChecker(IPlateau plateau)
        {
            _plateau = plateau;
        }
        public bool IsValid(ISpot spot)
        {
            return spot.X <= _plateau.EastBoundary;
        }
    }
}