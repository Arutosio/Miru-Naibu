﻿using System;
using System.Collections;
using System.Text.RegularExpressions;
using Miru_Naibu.Entities;
using Miru_Naibu.Library;
using static System.ConsoleColor;
namespace Miru_Naibu
{
    class Program
    {//Command to make a release: dotnet publish -c Release -r win10-x64 OR linux-x64
        static void Main(string[] args)
        {
            //Run FASE - Checking

            MiruNaibu terminal = MiruNaibu.GetMiruNaibuInstance;
            //Start
            string cmd = "";
            do {
            terminal.ReadyString();
            cmd = Console.ReadLine();
            if(cmd.ToLower().Replace(" ","").Equals("exit")) { break; }
            else if (!string.IsNullOrEmpty(cmd) && !string.IsNullOrWhiteSpace(cmd)){
                terminal.RunCommand(Command.CmdSplit(cmd)); }
            } while (true);
        }
    }
}
