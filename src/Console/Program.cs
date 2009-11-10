using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using MarsRovers.Console.Exceptions;
using MarsRovers.Core;

namespace MarsRovers.Console
{
    /* This Console Project is just an example of usage of the MarsRover.Core api */
    class Program
    {
        private const string INSTRUCTIONS = "Insert the Rovers Commands (To execute use RUN command):";
        private static StringBuilder commands;
        private static StringBuilder output;
        static void Main(string[] args)
        {
            try
            {
                SetUp(args);
                ExecuteCommands();
                DisplayOutput();
            }
            catch(Exception ex)
            {
                ex.Message.PrintLn();
            }

        }

        private static void SetUp(string[] args)
        {
            if (args.IsEmpty())
            {
                DisplayInstructions();
                ReceiveCommands();
            }
            else
            {
                InterpretParameters(args);
            }
        }

        private static void InterpretParameters(string[] args)
        {
            if(args[0] == "?")
            {
                DisplayHelp();
            }
            else
            {
                GetCommandsFromFile(args[0]);
            }
            
        }

        private static void DisplayHelp()
        {
            throw new HelpException();
        }

        private static void GetCommandsFromFile(string filePath)
        {
            StreamReader file = new StreamReader(File.Open(filePath, FileMode.Open));
            commands = new StringBuilder(file.ReadToEnd());
            file.Dispose();
        }
        
        private static void DisplayOutput()
        {
            output.ToString().Print();
        }

        private static void DisplayInstructions()
        {
            INSTRUCTIONS.PrintLn();
        }

        private static void ExecuteCommands()
        {
            var manager = new RoversManager();
            InstantiateOutput();
            output.AppendLine(manager.Execute(commands.ToString()));
        }

        private static void InstantiateOutput()
        {
            output = new StringBuilder();
            output.AppendLine("\nExecution Output:\n");
        }

        private static void ReceiveCommands()
        {
            commands = new StringBuilder();
            while (true)
            {
                var cmd = System.Console.ReadLine();
                if (cmd == "RUN")
                    break;
                commands.AppendLine(cmd);
            }
        }
    }

    public static class HelperExtensions
    {
        public static void PrintLn(this string text)
        {
            System.Console.WriteLine(text);
        }

        public static void Print(this string text)
        {
            System.Console.Write(text);
        }

        public static bool IsEmpty(this string[] strings)
        {
            return strings.All(String.IsNullOrEmpty);
        }
    }
}
