using System;
using System.Collections;
using Miru_Naibu.Command;
using Miru_Naibu.Entities;
using Miru_Naibu.Library;
using static System.ConsoleColor;
namespace Miru_Naibu
{
    class Program
    {
        static void Main(string[] args)
        {
            //Start FASE - Checking

            ArrayList cmd = new ArrayList();
            //Start
            ColorLine.WriteC("Console:Aru> ", Green);
            Console.WriteLine(User.GetUserInstance.Username);
            Setting cmdSet = new Setting("nome","setting","setting","lalalalal");
            Console.WriteLine(cmdSet.Name + cmdSet.Type + cmdSet.Cmd + cmdSet.x);
            Console.ReadKey();
        }
    }
}
