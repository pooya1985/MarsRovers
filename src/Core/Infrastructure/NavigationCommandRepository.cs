using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MarsRovers.Core.Services;

namespace MarsRovers.Core
{
    public class NavigationCommandRepository :IEnumerable<NavigationCommand>
    {
        public ICollection<NavigationCommand> _commands;

        public NavigationCommandRepository(params NavigationCommand[] commands)
        {
            _commands = new List<NavigationCommand>(commands);
        }

        public NavigationCommand GetCommand(char cmd)
        {
            return _commands.First(c => c.Is(cmd));
        }

        public IEnumerator<NavigationCommand> GetEnumerator()
        {
            return _commands.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Add(NavigationCommand command)
        {
            _commands.Add(command);
        }
    }
}