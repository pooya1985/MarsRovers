namespace MarsRovers.Core.Services
{
    public class DeploymentCommand
    {
        private Coordinate _coordinate;
        private IHeading _heading;
        public Coordinate Coordinate { get { return _coordinate; } }
        public IHeading Heading { get { return _heading; } }

        public DeploymentCommand(Coordinate coordinate, IHeading heading)
        {
            _coordinate = coordinate;
            _heading = heading;
        }


    }
}