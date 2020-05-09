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
            // /*Testring*/
            // Console.WriteLine("ASDF");
            // Console.Write("QWER");
            // ProgBar x = new ProgBar(22);
            // for(double i = 0; i <= 23452; i += 0.5) {
            //     x.PrintProgress(x.PercentCalculation(i,23452));
            //     //System.Threading.Thread.Sleep(50);
            // }
            // /*END Testring*/
            MiruNaibu terminal = MiruNaibu.GetMiruNaibuInstance;
            //Start
            string inputStr = ""; 
            do {
                terminal.ReadyString();
                inputStr = Console.ReadLine();
                //PluginManager.Start(CmdSplit(cmd));
                if(inputStr.ToLower().Replace(" ","").Equals("exit")) { break; }
                else if (!string.IsNullOrEmpty(inputStr) && !string.IsNullOrWhiteSpace(inputStr)) {
                    terminal.DoCommand(inputStr); }
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
