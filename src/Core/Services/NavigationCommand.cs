using System;

namespace MarsRovers.Core.Services
{
    public class NavigationCommand
    {
        private char _command;
        private Action<IRover> _navigationMethod;
        public NavigationCommand(char command,Action<IRover> navigationMethod)
        {
            _command = command;
            _navigationMethod = navigationMethod;
        }

        public void Navigate(IRover rover)
        {
            _navigationMethod(rover);
        }

        public bool Is(char command)
        {
            return Char.ToUpperInvariant(_command).Equals(Char.ToUpperInvariant(command));
        }
    }
}