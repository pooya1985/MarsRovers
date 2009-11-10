using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MarsRovers.Core
{
    public class HeadingRepository : IEnumerable<IHeading>
    {
        private IList<IHeading> _headings;

        public HeadingRepository(params IHeading[] headings)
        {
            _headings = new List<IHeading>(headings);
        }

        public IHeading GetHeading(char heading)
        {
            return _headings.First(h => h.Code.Equals(heading));
        }
        public void Add(IHeading heading)
        {
            _headings.Add(heading);
        }
        public IEnumerator<IHeading> GetEnumerator()
        {
            return _headings.GetEnumerator();    
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}