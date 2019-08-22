using System;
using System.Collections.Generic;
using Miru_Naibu.Command;
using Miru_Naibu.Library;
using static System.ConsoleColor;
using ClassCmd = Miru_Naibu.Command.Command;

namespace Miru_Naibu.Entities
{
    public class MiruNaibu
    {
        private MiruNaibu() {
            ClassCmd.LoadCommands();
        }
        internal void ReadyString()
        {
            ColorLine.WriteC(Environment.MachineName, Cyan);
            ColorLine.WriteC("@", Magenta);
            ColorLine.WriteC(User.GetUserInstance.Username, Green);
            ColorLine.WriteC("> ", Yellow);
        }
        internal void RunCommand(string cmdLine)
        {
            List<string> cmdList = ClassCmd.CmdSplit(cmdLine);
            switch (cmdList[0]) {
                case "help":
                    Help.HelpSwitch(cmdList);
                break;
                case "setting":
                break;
                case "cd":
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