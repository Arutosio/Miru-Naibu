using System;
using System.Collections.Generic;
using Miru_Naibu.Library;
using Miru_Naibu.Entities;
using CMD = Miru_Naibu.Entities.Command;
using PluginBase;
using static System.ConsoleColor;

namespace Miru_Naibu.MethodCommandSystem
{
    public sealed class Help
    {
        public static void HelpSwitch(List<string> subCmdList) {
            switch (subCmdList.Count) {
                case 0:
                CommandList();
                break;
                case 1:
                CommandInfo(subCmdList[0]);
                break;
                default:
                Console.WriteLine("Command not found");
                break;
            }
        }
        private static void CommandList() {
            Console.WriteLine("Command List:\r\n");
            foreach (ACommand cmd in CMD.commandList) {
                CommandInfo(cmd.Cmd);
            }
            foreach (ACommand cmd in Miru_Naibu.Library.PluginManager.commands)
            {
                CommandInfo(cmd.Cmd);
            }
            Console.WriteLine($"Numer of command: {CMD.commandList.Count}");
        }
        private static void CommandInfo(string cmd) {
            bool found = false;
            foreach (CMD cmdObj in CMD.commandList) 
            {
                if (cmdObj.Cmd.Equals(cmd)) {
                    CommandInfo(cmdObj);
                    found = true;
                    break;
                }
            } 
            if (!found)
            {
                foreach(ACommand cmdObj in Miru_Naibu.Library.PluginManager.commands)
                {
                    if (cmdObj.Cmd.Equals(cmd))
                    {
                        CommandInfo(cmdObj);
                        found = true;
                        break;
                    }
                }
            }
            else if(!found) { Console.WriteLine($"Command {cmd} not found."); }
        }
        private static void CommandInfo(ACommand cmdObj)
        {
            Console.WriteLine("\\ Name: " + cmdObj.Name);
            Console.Write(" |Author: "); ColorLine.WriteLineC(cmdObj.Author, Yellow);
            Console.Write(" |Type: "); ColorLine.WriteLineC(cmdObj.Type, Yellow);
            Console.Write(" |Command: "); ColorLine.WriteLineC(cmdObj.Cmd, Cyan);
            Console.Write(" `Description: " + cmdObj.Description + "\r\n");
            Console.WriteLine();
        }
    }
}