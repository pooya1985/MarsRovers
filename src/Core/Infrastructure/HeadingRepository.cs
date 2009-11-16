using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MarsRovers.Core
{
    public class HeadingRepository : IEnumerable<Heading>
    {
        private IList<Heading> _headings;

        public HeadingRepository(params Heading[] headings)
        {
            _headings = new List<Heading>(headings);
        }

        public Heading GetHeading(char heading)
        {
            return _headings.First(h => h.Code.Equals(heading));
        }
        public void Add(Heading heading)
        {
            _headings.Add(heading);
        }
        public IEnumerator<Heading> GetEnumerator()
        {
            return _headings.GetEnumerator();    
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}