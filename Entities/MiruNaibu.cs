using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Miru_Naibu.Library;
using PluginBase;
using static System.ConsoleColor;

namespace Miru_Naibu.Entities
{
    public class MiruNaibu
    {
        public static DirectoryInfo Root { get; set; }
        public PluginManager PluginManager { get; }
        public CommandsManager CmdManager { get; set; }
        private MiruNaibu() {
            PluginManager = new PluginManager(new DirectoryInfo(Directory.GetCurrentDirectory()), "Plugins");
            CmdManager = new CommandsManager(PluginManager.ReloadPlugins(PluginManager.PluginsPaths));
            Root = new DirectoryInfo(Directory.GetCurrentDirectory());
        }
        internal void ReadyString()
        {
            Console.WriteLine();
            ColorLine.WriteC(Environment.UserName, Green);
            ColorLine.WriteC("@", Magenta);
            //Console.Write("M:");
            ColorLine.WriteC(Environment.MachineName, Cyan);
            Console.Write(" Dir: ");
            ColorLine.WriteLineC(Root.FullName, Yellow);
            Console.Write("$> ");
        }
        public void DoCommand(string inputStr)
        {
            string[] strSplit = inputStr.Split(' ');
            string cmd = strSplit.First();
            if (string.IsNullOrWhiteSpace(cmd)) 
            {
                Console.WriteLine("Write a command.");
            } 
            else if(strSplit.Length <= 1) 
            {
                ICommand command = CommandsManager.FullCommands.FirstOrDefault(c => c.Cmd == cmd);
                if (command != null) { command.Execute(); } 
                else { 
                    Console.WriteLine($"Command \"{cmd}\" not found.");
                }
            }
            else 
            {
                int index = inputStr.IndexOf(cmd + " ");
                string cmdParams = (index < 0) ? inputStr : inputStr.Remove(index, cmd.Length + 1);
                ICommand command = CommandsManager.FullCommands.FirstOrDefault(c => c.Cmd == cmd);
                if (command != null) { command.Execute(cmdParams); } 
                else { 
                    Console.WriteLine($"Command \"{cmd}\" not found.");
                }
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