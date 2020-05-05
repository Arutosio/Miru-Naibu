using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Miru_Naibu.Library;
using static System.ConsoleColor;
using PluginBase;

namespace Miru_Naibu.Entities
{
    public class Command : ICommand
    {
        public string Name { get => Name; set => Name = value; }
        public string Author { get => Author; set => Author = value; }
        public string Type { get => Type; set => Type = value; }
        public string Cmd { get => Cmd; set => Cmd = value; }
        public string Description { get => Description; set => Description = value; }
        public int ActionCount { get => ActionCount; set => ActionCount = value; }

        public Command(string name,string author, string type, string cmd,string description, int actionCount) {
            Name = name;
            Author = author;
            Type = type;
            Cmd = cmd;
            Description = description;
            ActionCount = actionCount;
        }
        //STATIC
        public static List<Command> commandList = new List<Command>();

        internal static void LoadCommands() {
            commandList.Add(new Command("Help","Arutosio","System","help","Info commands",0));
            commandList.Add(new Command("Setting", "Arutosio", "System","setting","Change setting",0));
            commandList.Add(new Command("ChangeDirectory", "Arutosio", "System","cd","Move in the directorys",0));
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

        public int Execute()
        {
            throw new NotImplementedException();
        }

        public int Execute(string param)
        {
            throw new NotImplementedException();
        }

        public int Execute(string[] subInCmd)
        {
            throw new NotImplementedException();
        }

        public int Execute(List<string> subInCmd)
        {
            throw new NotImplementedException();
        }
    }
}