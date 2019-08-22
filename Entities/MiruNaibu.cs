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
        public User User { get; }
        private MiruNaibu() {
            User = User.GetUserInstance;
            ClassCmd.LoadCommands();
        }
        internal void ReadyString()
        {
            ColorLine.WriteC(Environment.MachineName, Cyan);
            ColorLine.WriteC("@", Magenta);
            ColorLine.WriteC(User.Username, Green);
            ColorLine.WriteC("> ", Yellow);
        }
        internal void RunCommand(string cmdLine)
        {
            foreach (string str in ClassCmd.CmdSplit(cmdLine)) {
                Console.WriteLine(str);
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