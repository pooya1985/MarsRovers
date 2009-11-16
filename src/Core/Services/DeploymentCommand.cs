using System;

namespace MarsRovers.Core.Services
{
    public class DeploymentCommand
    {
        private Position _position;
        private Heading _heading;
        public Position Position { get { return _position; } }
        public Heading Heading { get { return _heading; } }

        public DeploymentCommand(Position position)
        {
            _position = position;
        }
    }
}