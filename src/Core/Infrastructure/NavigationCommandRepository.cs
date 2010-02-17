using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MarsRovers.Core.Services;

namespace MarsRovers.Core
{
    public static class NavigationCommandRepository
    {
        private static NavigationCommand[] _commands ={
                                                 new NavigationCommand('L', r => r.RotateLeft()),
                                                 new NavigationCommand('R', r => r.RotateRight()),
                                                 new NavigationCommand('M', r => r.Increment())
                                                      };
        
        public static NavigationCommand GetCommand(char cmd)
        {
            return _commands.First(c => c.Is(cmd));
        }

    }
}