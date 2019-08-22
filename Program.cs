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
            terminal.RunCommand(cmd);
            } while (!cmd.ToLower().Replace(" ","").Equals("exit"));
            //Console.WriteLine(User.GetUserInstance.Username);
            //Setting cmdSet = new Setting("nome","setting","setting","lalalalal");
            //Console.WriteLine(cmdSet.Name + cmdSet.Type + cmdSet.Cmd + cmdSet.x);
        }
    }
}
