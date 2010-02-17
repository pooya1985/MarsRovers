using System;
using System.Text;
using MarsRovers.Core.Domain;
using MarsRovers.Core.Implementation;

namespace MarsRovers.Core.Services
{
    public class RoverCommandHandler
    {
        private const char LINE_BREAK = '\n';
        private static StringBuilder _output;
        public static string ExecuteCommands(RoverCommand[] commands)
        {
            _output = new StringBuilder();
            foreach (var cmd in commands)
            {
                Rover rover = RoverDeployer.Deploy(cmd.DeploymentCommand);
                rover.ExecuteCommands(cmd.NavigationCommands);
                AppendToOutput(rover);
            }
            return _output.ToString();
        }

        private static void AppendToOutput(Rover rover)
        {
            _output.Append(rover);
            _output.Append(LINE_BREAK);
        }
    }
}