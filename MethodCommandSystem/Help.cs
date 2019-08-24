using System;
using System.Collections.Generic;
using Miru_Naibu.Library;
using Miru_Naibu.Entities;
using CMD = Miru_Naibu.Entities.Command;
using static System.ConsoleColor;

namespace Miru_Naibu.MethodCommandSystem
{
    public sealed class Help
    {
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
            foreach (CMD cmd in CMD.commandList) {
                CommandInfo(cmd.Cmd);
            }
            Console.WriteLine($"Numer of command: {CMD.commandList.Count}");
        }
        private static void CommandInfo(string cmd) {
            bool found = false;
            foreach (CMD cmdObj in CMD.commandList) {
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