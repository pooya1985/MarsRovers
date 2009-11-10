using System;
using System.Collections.Generic;
using System.Text;
using MarsRovers.Core.Extensions;

namespace MarsRovers.Core
{
    /* this object is responsible to coordinate the Rovers */
    public class RoversManager
    {
        private const char LINE_BREAK = '\n';
        private const char SEPARATOR = ' ';

        private Plateau _plateau;
        private StringBuilder _output;
        
        public string Execute(string commands)
        {
            _output = new StringBuilder();

            //Resolve possible issues regarding Line Break Encoding
            commands = commands.FixLineBreak();

            InitializePlateau(commands);
            ExecuteRoversCommands(commands);
            return _output.ToString();
        }
        

        public int GetPlateauSize()
        {
            return _plateau.GetSize();
        }

        private void InitializePlateau(string commands)
        {
            var position = ParsePlateauLimitFrom(commands);
            
            _plateau = new Plateau(position);
        }

        private Position ParsePlateauLimitFrom(string command)
        {
            var cmd = command.Split(LINE_BREAK)[0].Split(SEPARATOR);
            var max_X = Int32.Parse(cmd[0]);
            var max_Y = Int32.Parse(cmd[1]);
            return new Position(max_X,max_Y);
        }

        private void ExecuteRoversCommands(string command)
        {
            var roverCommands = command.Split(LINE_BREAK);

            for (int i = 1; i <= roverCommands.Length - 1; i += 2)
            {
                var setUpCommand = roverCommands[i];
                var behaviorCommand = roverCommands[i + 1];

                Rover rover = GetNewRover(setUpCommand);

                SendCommandToRover(rover,behaviorCommand);
                _output.Append(String.Concat(rover.ToString(), LINE_BREAK));
            }
        }

        private Rover GetNewRover(string setUpCommand)
        {
            Position initialPosition = ParseRoverInitialPositionFrom(setUpCommand);
            char initialHeading = ParseRoverInitialHeadingFrom(setUpCommand);

            return new Rover(_plateau, initialPosition, initialHeading);
        }

        private Position ParseRoverInitialPositionFrom(string command)
        {
            var cmd = command.Split(SEPARATOR);
            var x = Int32.Parse(cmd[0]);
            var y = Int32.Parse(cmd[1]);
            return new Position(x, y);
        }

        private char ParseRoverInitialHeadingFrom(string command)
        {
            return Char.Parse(command.Split(SEPARATOR)[2]);
        }

        private void SendCommandToRover(Rover rover,IEnumerable<char> command)
        {
            foreach(char cmd in command)
            {
                switch (cmd)
                {
                    case 'L':
                        rover.RotateLeft();
                        break;
                    case 'R':
                        rover.RotateRight();
                        break;
                    case 'M':
                        rover.Move();
                        break;
                }
            }
            
        }
    }
}