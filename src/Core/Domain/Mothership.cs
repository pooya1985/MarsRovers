using System;
using System.Collections.Generic;
using System.Text;
using MarsRovers.Core.Domain.Model;
using MarsRovers.Core.Domain.Services;
using MarsRovers.Core.Domain.Validation;
using MarsRovers.Core.Implementation;
using MarsRovers.Core.Services;

namespace MarsRovers.Core.Domain
{
    public class Mothership
    {
//        private const char LINE_BREAK = '\n';

        private IPlateau _plateau;
        private CommandInterpreter _interpreter;
        private string _output;



        public string Execute(string commands)
        {
            SetUp(commands);
            ExecuteRoversCommands();
            return _output;
        }

        private void SetUp(string commands)
        {
            BuildInterpreter(commands);
            InitializePlateau(commands);
            InitializeBoundaryChecker();
        }

        private void InitializeBoundaryChecker()
        {
            BoundaryChecker.Initialize(_plateau);
        }
        
        private void BuildInterpreter(string commands)
        {
            _interpreter = new CommandInterpreter(commands);
        }

        public int GetPlateauSize()
        {
            return _plateau.GetSize();
        }

        private void InitializePlateau(string cmd)
        {
            var coordinates = _interpreter.GetMaxCoordinates(cmd);
            var x = coordinates[0];
            var y = coordinates[1];

            _plateau = new MarsPlateau(x,y);
        }

        private void ExecuteRoversCommands()
        {
            var roverCommands = _interpreter.GetRoverCommands();

            _output = RoverCommandHandler.ExecuteCommands(roverCommands);
        }

  }
}