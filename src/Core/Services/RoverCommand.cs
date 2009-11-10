using System;
using System.Collections.Generic;
using System.Linq;

namespace MarsRovers.Core.Services
{
    public class RoverCommand
    {
        private DeploymentCommand _depCommand;
        private IList<NavigationCommand> _navNavigationCommands;

        public  DeploymentCommand DeploymentCommand
        {
            get{ return _depCommand;}
        }

        public IList<NavigationCommand> NavigationCommands
        {
            get { return _navNavigationCommands; }
        }

        public RoverCommand(DeploymentCommand deploymentCommand, IEnumerable<NavigationCommand> commands)
        {
            _depCommand = deploymentCommand;
            _navNavigationCommands = commands.ToList();
        }
    }
}