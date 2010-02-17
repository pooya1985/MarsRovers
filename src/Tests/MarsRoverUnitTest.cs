using System;
using MarsRovers.Core;
using MarsRovers.Core.Domain;
using NUnit.Framework;

namespace MarsRovers.Tests
{
    [TestFixture]
    public class MarsRoverUnitTest
    {
        private Mothership manager;
        private string command = "5 5\n1 2 N\nLMLMLMLMM\n3 3 E\nMMRMMRMRRM";
        //private string command = "5 5\n";

        [SetUp]
        public void TestSetUp()
        {
            manager = new Mothership();
        }

        [Test]
        public void Should_Set_The_Size_Of_The_Plateu_With_The_First_Line_Commands()
        {
            manager.Execute(command);
            int result = manager.GetPlateauSize();
            Assert.AreEqual(25, result);
        }

        [Test]
        public void Should_Set_the_Position_Of_Rover_From_Second_Line_Commands()
        {
            var result = manager.Execute(command).Split('\n')[0];
            var expected = "1 3 N";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Should_Execute_Commands_Of_Both_Rovers()
        {
            var result = manager.Execute(command);
            var expected = "1 3 N\n5 1 E\n";
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void Should_Thrown_SpotOutsidePlateauException_If_rover_tries_to_move_outside_of_plateau()
        {
            var cmd = "5 5\n0 0 S\nM";
            Assert.That(Throws<InvalidCommandException>(() => manager.Execute(cmd)));
                        
        }

        private static bool Throws<TException>(Action action) where TException : Exception
        {
            try
            {
                action();
            }
            catch(TException exception)
            {
                return true;
            }
            return false;
        }
    }
}
