using System;
using MarsRovers.Core.Domain.Model;

namespace MarsRovers.Core.Services
{
    public class NavigationCommand : ICommand
    {
        private char _command;
        private Action<Position> _commandToExecute;
        public NavigationCommand(char command, Action<Position> expressionToExecute)
        {
            _command = command;
            _commandToExecute = expressionToExecute;
        }

        public bool Is(char command)
        {
            return Char.ToUpperInvariant(_command).Equals(Char.ToUpperInvariant(command));
        }

        public void Execute(Position position)
        {
            _commandToExecute(position);
        }
    }

    public interface ICommand
    {
        void Execute(Position position);
    }
}