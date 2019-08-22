using System;
using System.Collections.Generic;
using Miru_Naibu.Library;
using static System.ConsoleColor;
//using ClassCmd = Miru_Naibu.Command.Command;

namespace Miru_Naibu.Command
{
    public class Help : Command
    {
        public Help(string name, string type, string cmd, string description) : base(name, type, cmd, description) {
              
        }
        public static void HelpSwitch(List<string> subCmdList) {
            switch (subCmdList.Count) {
                case 1:
                CommandList();
                break;
                case 2:
                CommandInfo(subCmdList[1]);
                break;
                default:
                Console.WriteLine("Command not found");
                break;
            }
        }
        private static void CommandList() {
            Console.WriteLine("Command List:\r\n");
            foreach (Command cmd in Command.commandList) {
                CommandInfo(cmd.Cmd);
            }
            Console.WriteLine($"Numer of command: {Command.commandList.Count}");
        }
        private static void CommandInfo(string cmd) {
            bool found = false;
            foreach (Command cmdObj in Command.commandList) {
                if (cmdObj.Cmd.Equals(cmd)) {
                    Console.WriteLine("\\ Name: "+cmdObj.Name);
                    Console.Write(" |Type: "); ColorLine.WriteLineC(cmdObj.Type, Yellow);
                    Console.Write(" |Command: "); ColorLine.WriteLineC(cmdObj.Cmd, Cyan);
                    Console.Write(" `Description: "+cmdObj.Description+"\r\n");
                    Console.WriteLine(); found = true;
                    break;
                }
            } if (!found) {Console.WriteLine($"Command {cmd} not found.");}
        }
    }
}