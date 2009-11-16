using System;

namespace MarsRovers.Core
{
    public class SpotOutsidePlateauException : Exception
    {
        public override string Message
        {
            get
            {
                return string.Format("The vehicle tryed to move to a spot outside of the plateau!");
            }
        }
    }
}