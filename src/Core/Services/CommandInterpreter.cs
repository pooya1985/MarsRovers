using System;
using System.Collections.Generic;
using MarsRovers.Core.Domain.Model;
using MarsRovers.Core.Extensions;
using MarsRovers.Core.Implementation;

namespace MarsRovers.Core.Services
{
    public class CommandInterpreter
    {

        private const char LINE_BREAK = '\n';
        private const char SEPARATOR = ' ';
        
        public static string _commands;

        public CommandInterpreter(string commands)
        {
            _commands = commands.FixLineBreak();
        }

        public Coordinate[] GetMaxCoordinates(string commands)
        {
            var cmd = commands.Split(LINE_BREAK)[0];
            return GetCordinatesFrom(cmd);
        }

        public RoverCommand[] GetRoverCommands()
        {
            var cmds = _commands.Split(LINE_BREAK);
            var roverCommands = new List<RoverCommand>();


            for (int i = 1; i <= cmds.Length - 1; i += 2)
            {
                var deploymentCommand = GetDeploymentCommandFrom(cmds[i]);
                
                var navigateCommands = GetNavigateCommands(cmds[i + 1]);
                roverCommands.Add(new RoverCommand(deploymentCommand, navigateCommands));
            }
            return roverCommands.ToArray();
        }

        private IEnumerable<NavigationCommand> GetNavigateCommands(string command)
        {
            foreach (var cmd in command)
            {
                yield return NavigationCommandRepository.GetCommand(cmd);
            }
        }

        private static Coordinate[] GetCordinatesFrom(string cmd)
        {
            var coordinateCmds = cmd.Split(SEPARATOR);
            var x = new Coordinate(Int32.Parse(coordinateCmds[0]));
            var y = new Coordinate(Int32.Parse(coordinateCmds[1]));
            return new[] {x, y};
        }

        private DeploymentCommand GetDeploymentCommandFrom(string cmd)
        {
            var coordinates = GetCordinatesFrom(cmd);
            var headingCode = Char.Parse(cmd.Split(SEPARATOR)[2]);
            var heading = HeadingRepository.GetHeading(headingCode);
            var initialSpot = new PlateauSpot(coordinates[0], coordinates[1]);
            var deploymentPosition = new Position(initialSpot,heading);
            return new DeploymentCommand(deploymentPosition);
        }
    }
}