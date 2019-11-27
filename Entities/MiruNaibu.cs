using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Miru_Naibu.Library;
using Miru_Naibu.MethodCommandSystem;
using PluginBase;
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
            ColorLine.WriteC(Environment.UserName, Green);
            ColorLine.WriteC("@", Magenta);
            //Console.Write("M:");
            ColorLine.WriteC(Environment.MachineName, Cyan);
            Console.Write(" Dir: ");
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
                    /*
                    */
                    if (cmdFirst == string.Empty) {
                        Console.WriteLine("Write a command.");
                    } 
                    else {
                        ACommand command = PluginManager.commands.FirstOrDefault(c => c.Cmd == cmdFirst);
                        if (command != null) { command.Switch(cmdList); } 
                        else { 
                            Console.WriteLine($"Command \"{cmdFirst}\" not found.");
                        }
                    }
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