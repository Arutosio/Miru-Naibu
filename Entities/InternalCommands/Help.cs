using System;
using System.Collections.Generic;
using Miru_Naibu.Library;
using PluginBase;
using static System.ConsoleColor;

namespace Miru_Naibu.Entities.InternalCommands
{
    public sealed class Help : ICommand
    {
        public string Name => "Help";
        public string Author => "Arutosio";
        public string Version => "0.0.1.0";
        public string Type => "System";
        public string Cmd => "help";
        public string Description => "Help is a command to help you";
        public int ActionCount { get => 0; set => ActionCount = value; }

        public Help() {}
        public int Execute()
        {
            CommandList();
            return 0;
        }
        public int Execute(string param)
        {
            CommandInfo(param);
            return 0;
        }
        public int Execute(string[] subInCmd)
        {
            throw new NotImplementedException();
        }
        public int Execute(List<string> subInCmd)
        {
            throw new NotImplementedException();
        }
        private void CommandList() 
        {
            Console.WriteLine("Command List:\r\n");
            int numCMD = 0;
            foreach (ICommand cmd in CommandsManager.FullCommands) {
                CommandInfo(cmd.Cmd);
                numCMD++;
            }
            Console.WriteLine($"Numer of command: {numCMD}");
        }
        private static void CommandInfo(string cmd) {
            foreach (ICommand cmdObj in CommandsManager.FullCommands) 
            {
                if (cmdObj.Cmd.Equals(cmd)) {
                    CommandInfo(cmdObj);
                    break;
                }
            }
            Console.WriteLine($"Command {cmd} not found."); 
        }
        private static void CommandInfo(ICommand cmdObj)
        {
            Console.WriteLine("\\ Name: " + cmdObj.Name);
            Console.Write(" |Author: "); ColorLine.WriteLineC(cmdObj.Author, Green);
            Console.Write(" |Version: "); ColorLine.WriteLineC(cmdObj.Version, Cyan);
            Console.Write(" |Type: "); ColorLine.WriteLineC(cmdObj.Type, Red);
            Console.Write(" |Command: "); ColorLine.WriteLineC(cmdObj.Cmd, Yellow);
            Console.Write(" `Description: " + cmdObj.Description + "\r\n");
            Console.WriteLine();
        }
    }
}