using System;
using Miru_Naibu.Entities;
using Miru_Naibu.Library;
using static System.ConsoleColor;
namespace Miru_Naibu
{
    class Program
    {
        public static string[] cmd = {"cd"};
        static void Main(string[] args)
        {
            
            ColorLine.WriteC("Console:Aru> ", Green);
            Console.WriteLine(User.GetUserInstance.Username);
            Console.ReadKey();
        }
    }
}
