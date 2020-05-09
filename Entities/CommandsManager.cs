using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Miru_Naibu.Library;
using static System.ConsoleColor;
using PluginBase;
using Miru_Naibu.Entities.InternalCommands;

namespace Miru_Naibu.Entities
{
    public class CommandsManager
    {
        public List<ICommand> SystemCommands { get; set; }
        public IEnumerable<ICommand> PluginCommands { get; set; }
        public static List<ICommand> FullCommands { get; set; }
        public CommandsManager(IEnumerable<ICommand> pluginCommands) {
            SystemCommands = GetSystemCommands();
            PluginCommands = pluginCommands;
            FullCommands = MergeEnumerableToList(GetSystemCommands(), pluginCommands);
        }

        private static List<ICommand> GetSystemCommands() 
        {
            List<ICommand> ret = new List<ICommand>();
            ret.Add(new Help());
            ret.Add(new Setting());
            ret.Add(new ChangeDirectory());
            return ret;
        }
        private static List<ICommand> MergeEnumerableToList(List<ICommand> mainCommands, IEnumerable<ICommand> toAddCommands)
        {
            if(mainCommands != null)
                mainCommands.AddRange(toAddCommands);
            return mainCommands;
        }
        // public static List<string> CmdSplit(string cmdLine) {
        //     List<string> cmdList = new List<string>();
        //     RegexOptions options = RegexOptions.None;
        //     Regex regex = new Regex("[ ]{2,}", options);     
        //     cmdLine = regex.Replace(cmdLine, " ");
        //     if (cmdLine[0] == ' ') {
        //         cmdLine.Substring(1);
        //     }
        //     foreach (string str in cmdLine.Split(' ')) {
        //         cmdList.Add(str);
        //     }
        //     return cmdList;
        // }
    }
}