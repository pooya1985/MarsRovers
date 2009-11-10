using System;

namespace MarsRovers.Console.Exceptions
{
    public class HelpException : Exception
    {
        public override string Message
        {
            get
            {
                return "\n\nUsage Options:\n\nMarsRover.Console.exe  --> Asks for the commands to be executed.\n                           Send 'RUN' command to execute them.\n\nMarsRover.Console.exe <Commands_File> --> Executes the commands \n                                         defined in the specified file.";
            }
        }
    }
}