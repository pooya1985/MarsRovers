using System;

namespace MarsRovers.Core
{
    public class InvalidCommandException : Exception
    {
        public override string Message
        {
            get
            {
                return string.Format("The command sent would send the rover outside of the plateau. Are you nuts?\nDo you know how much a Rover costs?\nDouble check your commands before sending them to mars, for Christ's sake.");
            }
        }
    }
}