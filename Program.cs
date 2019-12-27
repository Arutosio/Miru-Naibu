using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Miru_Naibu.Entities;
using Miru_Naibu.Library;
using PluginBase;
using static System.ConsoleColor;
namespace Miru_Naibu
{
    class Program
    {//Command to make a release: dotnet publish -c Release -r win10-x64 OR linux-x64
        static void Main(string[] args)
        {
            /*Testring*/
            Console.WriteLine("ASDF");
            Console.Write("QWER");
            ProgBar x = new ProgBar(22);
            for(double i = 0; i <= 100; i += 0.5) {
                x.PrintProgress(i);
                System.Threading.Thread.Sleep(50);
            }
            /*END Testring*/
            if(!PluginManager.CheckDirPlugins()) {
               Console.WriteLine("Install...");
               PluginManager.Install();
            }
            if(!PluginManager.IsDirectoryEmpty()) {
                Console.WriteLine("LoadPlugins....");
                PluginManager.ReloadPlugins();
            }
            //Run FASE - Checking
            MiruNaibu terminal = MiruNaibu.GetMiruNaibuInstance;
            //Start
            string cmd = ""; 
            do {
                terminal.ReadyString();
                cmd = Console.ReadLine();
                //PluginManager.Start(CmdSplit(cmd));
                if(cmd.ToLower().Replace(" ","").Equals("exit")) { break; }
                else if (!string.IsNullOrEmpty(cmd) && !string.IsNullOrWhiteSpace(cmd)) {
                    terminal.RunCommand(Command.CmdSplit(cmd)); }
            } while (true);
            /*
            */
            Console.ReadKey();
        }
        public static string[] CmdSplit(string cmdLine) {
            if(cmdLine.Length != 0){
                RegexOptions options = RegexOptions.None;
                Regex regex = new Regex("[ ]{2,}", options);     
                cmdLine = regex.Replace(cmdLine, " ");
                if (cmdLine[0] == ' ') {
                    cmdLine.Substring(1);
                }
                return cmdLine.Split(' ');
            } else {return new string[] {};}
        }
    }
}
