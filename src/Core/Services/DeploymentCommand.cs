using System;
using MarsRovers.Core.Domain.Model;

namespace MarsRovers.Core.Services
{
    public class DeploymentCommand 
    {
        private Position _position;

        public Position Position { get { return _position; } }


        public DeploymentCommand(Position position)
        {
            _position = position;
        }

    }
}