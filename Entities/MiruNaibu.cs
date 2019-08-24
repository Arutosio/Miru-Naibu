using System;
using System.Collections.Generic;
using Miru_Naibu.Library;
using Miru_Naibu.MethodCommandSystem;
using static System.ConsoleColor;

namespace Miru_Naibu.Entities
{
    public class MiruNaibu
    {
        private MiruNaibu() {
            Command.LoadCommands();
        }
        internal void ReadyString()
        {
            Console.Write("M:");
            ColorLine.WriteC(Environment.MachineName, Cyan);
            ColorLine.WriteC("@", Magenta);
            ColorLine.WriteC(User.GetUserInstance.Username, Green);
            Console.Write("Dir:");
            ColorLine.WriteLineC(ChangeDirectory.CurrentDirectory.FullName, Yellow);
            Console.Write("$> ");
        }
        public void RunCommand(List<string> cmdList)
        {
            string cmdFirst = cmdList[0];
            if (cmdList.Count > 1) { cmdList.RemoveAt(0); }
            switch (cmdFirst) {
                case "help":
                    Help.HelpSwitch(cmdList);
                break;
                case "setting":
                    Setting.SettingSwitch(cmdList);
                break;
                case "cd":
                    ChangeDirectory.ChangeDirectorySwitch(cmdList);
                break;
                default:
                    Console.WriteLine($"Command \"{cmdList[0]}\" not found.");
                break;
            }
        }
        private static MiruNaibu instance = null;
        private static readonly object padlock = new object();
        public static MiruNaibu GetMiruNaibuInstance { 
            get {
                lock (padlock) {
                    if(MiruNaibu.instance == null) {
                        return new MiruNaibu();
                    } 
                    return MiruNaibu.instance;
                }
            }
        }
    }
}