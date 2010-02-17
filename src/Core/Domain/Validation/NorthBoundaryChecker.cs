using MarsRovers.Core.Domain.Model;
using MarsRovers.Core.Domain.Services;

namespace MarsRovers.Core.Domain.Validation
{
    public class NorthBoundaryChecker  : BaseChecker, IBoundaryChecker
    {
        public NorthBoundaryChecker(IPlateau plateau)
        {
            _plateau = plateau;
        }

        public bool IsValid(ISpot spot)
        {
            return spot.Y <= _plateau.NorthBoundary;
        }
    }
}