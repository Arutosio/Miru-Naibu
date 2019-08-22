using System;
using System.Collections.Generic;
using Miru_Naibu.Command;
using ClassCmd = Miru_Naibu.Command.Command;

namespace Miru_Naibu.Entities
{
    public class MiruNaibu
    {
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
        private MiruNaibu() {
            ClassCmd.LoadCommands();
        }
        internal string ReadyString()
        {
            return "ConsoleReady:";
        }

        internal void RunCommand(string v)
        {
            throw new NotImplementedException();
        }
    }
}