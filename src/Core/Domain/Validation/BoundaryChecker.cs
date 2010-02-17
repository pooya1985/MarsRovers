using System;
using System.Collections.Generic;
using MarsRovers.Core.Domain.Model;
using MarsRovers.Core.Domain.Services;

namespace MarsRovers.Core.Domain.Validation
{
    public class BoundaryChecker
    {

        private static Func<IBoundaryChecker[]> GetCheckers =
            () => { throw new Exception("Boundary checker has to be initialized"); };

        public static bool IsValid(ISpot spot)
        {
            foreach (var checker in GetCheckers())
            {
                if (!checker.IsValid(spot))
                    return false;
            }
            return true;
        }

        public static void Initialize(IPlateau _plateau)
        {
            GetCheckers = () =>
                              {
                                  return new List<IBoundaryChecker>
                                             {
                                                 new NorthBoundaryChecker(_plateau),
                                                 new SouthBoundaryChecker(_plateau),
                                                 new EastBoundaryChecker(_plateau),
                                                 new WestBoundaryChecker(_plateau)
                                             }.ToArray();
                              };
        }

        
    }
}