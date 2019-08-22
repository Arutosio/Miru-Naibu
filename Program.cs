using System;
using System.Collections;
using System.Text.RegularExpressions;
using Miru_Naibu.Command;
using Miru_Naibu.Entities;
using Miru_Naibu.Library;
using static System.ConsoleColor;
using ClassCmd = Miru_Naibu.Command.Command;
namespace Miru_Naibu
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start FASE - Checking

            //Start
            MiruNaibu terminal = MiruNaibu.GetMiruNaibuInstance;
            string cmd = "";
            do {
            terminal.ReadyString();
            cmd = Console.ReadLine();
            if(cmd.ToLower().Replace(" ","").Equals("exit")) {break;}
            terminal.RunCommand(cmd);
            } while (true);
        }
    }
}
