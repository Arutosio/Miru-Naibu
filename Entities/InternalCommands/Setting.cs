using System;
using System.Collections.Generic;
using PluginBase;

namespace Miru_Naibu.Entities.InternalCommands
{
    public sealed class Setting : ICommand
    {
        public string Name => "Setting";
        public string Author => "Arutosio";
        public string Version => "0.0.1.0";
        public string Type => "System";
        public string Cmd => "setting";
        public string Description => "You can chnage the system configuration with this command";
        public int ActionCount { get => 0; set => ActionCount = value; }

        public int Execute()
        {
            Console.WriteLine("Setting Excute");
            return 0;
        }

        public int Execute(string param)
        {
            Console.WriteLine($"Setting Excute, param: {param}");
            return 0;
        }

        public int Execute(string[] subInCmd)
        {
            throw new System.NotImplementedException();
        }

        public int Execute(List<string> subInCmd)
        {
            throw new System.NotImplementedException();
        }
    }
}