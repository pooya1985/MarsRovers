using System;
using System.Collections.Generic;
using System.Text;
using MarsRovers.Core.Extensions;
using MarsRovers.Core.Services;

namespace MarsRovers.Core
{
    public class RoversManager
    {
        private const char LINE_BREAK = '\n';

        private Plateau _plateau;
        private NavigationCommandRepository _navRepository;
        private HeadingRepository _headingRepository;
        private CommandInterpreter interpreter;
        private StringBuilder _output;

        public string Execute(string commands)
        {
            SetUp(commands);
            
            ExecuteRoversCommands();

            return _output.ToString();
        }

        private void SetUp(string commands)
        {
            _output = new StringBuilder();

            InitializePlateau(commands);
            PopulateNavigationCommandRepository();
            PopulateHeadingsRepository();
            InterpretCommands(commands);
        }
        
        private void PopulateHeadingsRepository()
        {
            _headingRepository = new HeadingRepository
                                     {
                                         new North(_plateau),
                                         new East(_plateau),
                                         new South(_plateau),
                                         new West(_plateau)

                                     };
        }

        private void PopulateNavigationCommandRepository()
        {
            _navRepository = new NavigationCommandRepository
                                 {
                                     new NavigationCommand('L', r => r.RotateLeft()),
                                     new NavigationCommand('R', r => r.RotateRight()),
                                     new NavigationCommand('M', r => r.Move())
                                 };
        }
        
        private void InterpretCommands(string commands)
        {
            interpreter = new CommandInterpreter(commands, _headingRepository, _navRepository);
        }

        public int GetPlateauSize()
        {
            return _plateau.GetSize();
        }

        private void InitializePlateau(string cmd)
        {
            _plateau = new MarsPlateau(CommandInterpreter.GetPlateauMaxSpot(cmd));
        }

        private void ExecuteRoversCommands()
        {
            var roverCommands = interpreter.GetRoverCommands();

            foreach (var cmd in roverCommands)
            {
                Rover rover = DeployRover(cmd.DeploymentCommand);
                Navigate(rover, cmd.NavigationCommands);

                _output.Append(GetOutputFrom(rover));
            }
        }

        private string GetOutputFrom(Rover rover)
        {
            return String.Concat(rover.ToString() , LINE_BREAK);
        }

        private Rover DeployRover(DeploymentCommand cmd)
        {
            return new Rover(cmd.Position);
        }

        private void Navigate(Vehicle rover,IEnumerable<NavigationCommand> cmds)
        {
            foreach (var cmd in cmds)
            {
                cmd.Navigate(rover);
            }
        }
    }
}