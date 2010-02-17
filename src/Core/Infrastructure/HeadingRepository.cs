using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MarsRovers.Core.Domain.Model;
using MarsRovers.Core.Implementation;

namespace MarsRovers.Core
{
    public static class HeadingRepository
    {
        private static IHeading[] _headings = { 
                                         new North(),
                                         new East(),
                                         new South(),
                                         new West()};

        public static IHeading GetHeading(char heading)
        {
            return _headings.First(h => h.Code.Equals(heading));
        }
        
        public static IHeading[] GetAll()
        {
            return _headings;
        }
    }
}