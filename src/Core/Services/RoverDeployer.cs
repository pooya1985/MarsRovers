using MarsRovers.Core.Implementation;
using MarsRovers.Core.Services;

namespace MarsRovers.Core.Domain
{
    public static class RoverDeployer
    {
        public static Rover Deploy(DeploymentCommand cmd)
        {
            return new Rover(cmd.Position);
        }
    }
}