using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Miru_Naibu.Library;
using static System.ConsoleColor;

namespace Miru_Naibu.Entities
{
    public class Command
    {
        private Command() {}
        public Command(string name, string type, string cmd,string description) {
            Name = name;
            Type = type;
            Cmd = cmd;
            Description = description;
        }
        public string Name { get; private set; }
        public string Type { get; private set; }
        public string Cmd { get; private set; }
        public string Description { get; private set; }

        
        //STATIC
        public static List<Command> commandList = new List<Command>();
        internal static void LoadCommands() {
            commandList.Add(new Command("Help","System","help","Info commands"));
            commandList.Add(new Command("Setting","System","setting","Change setting"));
            commandList.Add(new Command("ChangeDirectory","System","cd","Move in the directorys"));
            //return commandList;
        }
        public static List<string> CmdSplit(string cmdLine) {
            List<string> cmdList = new List<string>();
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);     
            cmdLine = regex.Replace(cmdLine, " ");
            if (cmdLine[0] == ' ') {
                cmdLine.Substring(1);
            }
            foreach (string str in cmdLine.Split(' ')) {
                cmdList.Add(str);
            }
            return cmdList;
        }
        internal List<string> RemoveFirstCommand(List<string> cmdList) {
            if (cmdList.Count > 1) { cmdList.RemoveAt(0); }
            return cmdList;
        }
        
        //////////Command List System
        internal static bool InstallCommand() {
            return false;
        }
        internal static bool UnistallCommand(string nameCmd) {
            foreach (Command cmd in commandList) {
                if(cmd.Name.Equals(nameCmd)) {
                    commandList.Remove(cmd);
                    return true;
                }
            }
            return false;
        }
    }
}