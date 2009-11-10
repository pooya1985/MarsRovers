using System;

namespace MarsRovers.Console.Exceptions
{
    public class InvalidArgumentPrefixException : Exception
    {
        public override string Message
        {
            get
            {
                return "Argument Prefix is Invalid.";
            }
        }
    }
}