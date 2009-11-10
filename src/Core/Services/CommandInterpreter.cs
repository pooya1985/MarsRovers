using System;
using System.Collections.Generic;
using MarsRovers.Core.Extensions;

namespace MarsRovers.Core.Services
{
    public class CommandInterpreter
    {

        private const char LINE_BREAK = '\n';
        private const char SEPARATOR = ' ';
        private HeadingRepository _headingRepository;
        private NavigationCommandRepository _navigateRepository;

        public static string _commands;

        public CommandInterpreter(string commands, HeadingRepository hRepository, NavigationCommandRepository nRepository )
        {
            _commands = commands.FixLineBreak();
            _headingRepository = hRepository;
            _navigateRepository = nRepository;

        }

        public static Coordinate GetPlateauMaxCoordinate(string commands)
        {
            var cmd = commands.Split(LINE_BREAK)[0];
            return GetCordinateFrom(cmd);
            
        }

        public IList<RoverCommand> GetRoverCommands()
        {
            var cmds = _commands.Split(LINE_BREAK);
            var roverCommands = new List<RoverCommand>();


            for (int i = 1; i <= cmds.Length - 1; i += 2)
            {
                var deploymentCommand = GetDeploymentCommandFrom(cmds[i]);
                
                var navigateCommands = GetNavigateCommands(cmds[i + 1]);
                roverCommands.Add(new RoverCommand(deploymentCommand, navigateCommands));
            }
            return roverCommands;
        }

        private IEnumerable<NavigationCommand> GetNavigateCommands(string command)
        {
            foreach (var cmd in command)
            {
                yield return _navigateRepository.GetCommand(cmd);
            }
        }

        private static Coordinate GetCordinateFrom(string cmd)
        {
            var coordinateCmds = cmd.Split(SEPARATOR);
            var max_X = Int32.Parse(coordinateCmds[0]);
            var max_Y = Int32.Parse(coordinateCmds[1]);
            return new Coordinate(max_X, max_Y);
        }

        private DeploymentCommand GetDeploymentCommandFrom(string cmd)
        {
            var headingCode = Char.Parse(cmd.Split(SEPARATOR)[2]);
            return new DeploymentCommand(GetCordinateFrom(cmd),_headingRepository.GetHeading(headingCode));
        }
    }
}