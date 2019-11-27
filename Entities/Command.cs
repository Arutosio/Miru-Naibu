using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Miru_Naibu.Library;
using static System.ConsoleColor;
using PluginBase;

namespace Miru_Naibu.Entities
{
    public class Command : ACommand
    {
        public override string Name { get; set; } = "NONE";
        public override string Author { get; set; } = "NONE";
        public override string Type { get; set; } = "NONE";
        public override string Cmd { get; set; } = "NONE";
        public override string Description { get; set; } = "NONE";
        public Command(string name,string author, string type, string cmd,string description) {
            Name = name;
            Author = author;
            Type = type;
            Cmd = cmd;
            Description = description;
        }
        //STATIC
        public static List<Command> commandList = new List<Command>();


        internal static void LoadCommands() {
            commandList.Add(new Command("Help","Arutosio","System","help","Info commands"));
            commandList.Add(new Command("Setting", "Arutosio", "System","setting","Change setting"));
            commandList.Add(new Command("ChangeDirectory", "Arutosio", "System","cd","Move in the directorys"));
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

        public override void OnJoin(List<string> cmdParam)
        {
            throw new NotImplementedException();
        }

        protected override void Switch(List<string> cmdParam)
        {
            throw new NotImplementedException();
        }

        protected override int Execute()
        {
            throw new NotImplementedException();
        }

        protected override int Execute(string param)
        {
            throw new NotImplementedException();
        }

        protected override int Execute(string[] subInCmd)
        {
            throw new NotImplementedException();
        }

        protected override void OnExit()
        {
            throw new NotImplementedException();
        }
    }
}