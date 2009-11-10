using System.Collections.Generic;

namespace MarsRovers.Core
{
    public class RoversRepository
    {
        private Queue<Rover> _rovers = new Queue<Rover>();

        public void AddRover(Rover rover)
        {
            _rovers.Enqueue(rover);
        }

        public Rover GetRover()
        {
            return _rovers.Dequeue();
        }
    }
}