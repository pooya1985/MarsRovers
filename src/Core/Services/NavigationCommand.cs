using System;

namespace MarsRovers.Core.Services
{
    public class NavigationCommand
    {
        private char _command;
        private Action<Vehicle> _navigationMethod;
        public NavigationCommand(char command,Action<Vehicle> navigationMethod)
        {
            _command = command;
            _navigationMethod = navigationMethod;
        }

        public void Navigate(Vehicle rover)
        {
            _navigationMethod(rover);
        }

        public bool Is(char command)
        {
            return Char.ToUpperInvariant(_command).Equals(Char.ToUpperInvariant(command));
        }
    }
}