using System;
using System.Collections.Generic;
using MarsRovers.Core.Domain.Model;
using MarsRovers.Core.Domain.Validation;
using MarsRovers.Core.Services;

namespace MarsRovers.Core.Implementation
{
    public class 
        Rover : Vehicle
    {
        private Position _position;
        private Queue<ICommand> _commands;
        
        public Rover(Position position)
        {
            _position = position;
            _commands = new Queue<ICommand>();
        }

        public Position Position
        {
            get { return _position; }
        }

        public void ExecuteCommands(ICommand[] commands)
        {
            if(AreValid(commands))
            {
                EnqueueCommands(commands);
                Execute();
            }
            else
            {
                throw new InvalidCommandException();
            }

        }

        private bool AreValid(ICommand[] commands)
        {
            var x = (int)_position.Spot.X;
            var y = (int)_position.Spot.Y;
            var h = HeadingRepository.GetHeading(_position.Heading.Code);
            var s = new PlateauSpot(x, y);
            var evalPosition = new Position(s, h);

            foreach (var command in commands)
            {
                command.Execute(evalPosition);
                if(!BoundaryChecker.IsValid(evalPosition.Spot))
                    return false;
            }
            return true;
        }

        private void Execute()
        {
            while (_commands.Count > 0)
            {
                var cmd = _commands.Dequeue();
                cmd.Execute(Position);
            }
        }

        private void EnqueueCommands(ICommand[] commands)
        {
            foreach (var command in commands)
            {
                _commands.Enqueue(command);
            }
        }
       
        public override string ToString()
        {
            return Position.ToString();
        }

    }
}