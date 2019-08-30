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
            /*
            if(!PluginManager.CheckDirPlugins()) {
               Console.WriteLine("Install...");
               PluginManager.Install();
            }
            if(!PluginManager.IsDirectoryEmpty()) {
                Console.WriteLine("LoadPlugins....");
                PluginManager.LoadPlugins();
            }

            Console.WriteLine(Path.Combine(Directory.GetCurrentDirectory(), @"SystemPlugin\HelloPlugin\bin\Debug\netcoreapp3.0\HelloPlugin.dll"));
            string[] x = {Path.Combine(Directory.GetCurrentDirectory(), @"SystemPlugin\HelloPlugin\bin\Debug\netcoreapp3.0\HelloPlugin.dll")}; 
            */
            //PluginManager.Start(x);
            //Run FASE - Checking
            MiruNaibu terminal = MiruNaibu.GetMiruNaibuInstance;
            //Start
            string cmd = ""; 
            do {
                terminal.ReadyString();
                cmd = Console.ReadLine();
                PluginManager.Start(CmdSplit(cmd));
                if(cmd.ToLower().Replace(" ","").Equals("exit")) { break; }
                else if (!string.IsNullOrEmpty(cmd) && !string.IsNullOrWhiteSpace(cmd)) {
                    terminal.RunCommand(Command.CmdSplit(cmd)); }
            } while (true);
            /*
            */
            Console.ReadKey();
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
