using System;
using System.Collections.Generic;
using System.IO;
using Miru_Naibu.Entities;
using Miru_Naibu.Library;
using PluginBase;

namespace Miru_Naibu.Entities.InternalCommands
{
    public sealed class ChangeDirectory : ICommand
    {
        public string Name => "ChangeDirectory";
        public string Author => "Arutosio";
        public string Version => "0.0.1.0";
        public string Type => "System";
        public string Cmd => "cd";
        public string Description => "To move in directory";
        public int ActionCount { get => this.ActionCount; set => this.ActionCount = value; }

        public ChangeDirectory() {}
        public int Execute()
        {
            ColorLine.WriteLineC("path", ConsoleColor.Yellow);
            return 0;
        }
        public int Execute(string param)
        {
            Switch(param);
            return 0;
        }
        public int Execute(string[] subInCmd)
        {
            throw new NotImplementedException();
        }

        public int Execute(List<string> subInCmd)
        {
            throw new NotImplementedException();
        }
        private void Switch(string param) 
        {
            switch (param) 
            {
                case "..":
                    DirManager.GoUnderDirectory(MiruNaibu.Root);
                break;
                default:
                    DirManager.GoSubDirectory(param);
                break;
            }
        }
    }
}