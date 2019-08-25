using System;
using System.Collections.Generic;
using System.IO;
using Miru_Naibu.Library;
using Miru_Naibu.MethodCommandSystem;
using static System.ConsoleColor;

namespace Miru_Naibu.Entities
{
    public class MiruNaibu
    {
        public DirectoryInfo CurrentDirectory { get; set; }
        private MiruNaibu() {
            CurrentDirectory = new DirectoryInfo(Directory.GetCurrentDirectory());
            Command.LoadCommands();
        }
        internal void ReadyString()
        {
            Console.Write("M:");
            ColorLine.WriteC(Environment.MachineName, Cyan);
            ColorLine.WriteC("@", Magenta);
            ColorLine.WriteC(Environment.UserName, Green);
            Console.Write(" Dir:");
            ColorLine.WriteLineC(CurrentDirectory.FullName, Yellow);
            Console.Write("$> ");
        }
        public void RunCommand(List<string> cmdList)
        {
            string cmdFirst = cmdList[0];
            cmdList.RemoveAt(0);
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
                case "ls":
                    ListOfElement.ListOfElementSwitch(cmdList);
                break;
                default:
                if (cmdList.Count<=0) {
                    Console.WriteLine("Write a command.");
                } else { Console.WriteLine($"Command \"{cmdList[0]}\" not found."); }
                break;
            }
        }
        private static MiruNaibu instance = null;
        private static readonly object padlock = new object();
        public static MiruNaibu GetMiruNaibuInstance { 
            get {
                lock (padlock) {
                    if(MiruNaibu.instance == null) {
                        instance = new MiruNaibu();
                    } 
                    return MiruNaibu.instance;
                }
            }
        }
    }
}