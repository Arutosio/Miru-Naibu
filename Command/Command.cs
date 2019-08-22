using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Miru_Naibu.Command
{
    public abstract class Command
    {
        private Command() {}
        public Command(string name, string type, string cmd,string description) {
            Name = name;
            Type = type;
            Cmd = cmd;
            Description = description;
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Cmd { get; set; }
        public string Description { get; set; }
        //STATIC
        private static List<Command> commandList = new List<Command>();
        internal static bool UnistallCmd(List<Command> commandList,string nameCmd) {
            foreach (Command cmd in commandList) {
                if(cmd.Name.Equals(nameCmd)) {
                    commandList.Remove(cmd);
                    return true;
                }
            }
            return false;
        }
         internal static void LoadCommands() {
            commandList.Add(new Help("Help","System","help","Info commands"));
            commandList.Add(new Setting("Setting","System","setting","Change setting"));
            commandList.Add(new Setting("ChangeDirectory","System","cd","Move in the directorys"));
            //return commandList;
        }
        public static string[] CmdSplit(string cmdLine) {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);     
            cmdLine = regex.Replace(cmdLine, " ");
            if (cmdLine[0] == ' ') {
                cmdLine.Substring(1);
            }
            return cmdLine.Split(' ');
        }
    }
}