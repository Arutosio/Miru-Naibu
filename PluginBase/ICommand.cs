using System;
using System.Collections.Generic;

namespace PluginBase
{
    public interface ICommand
    {

        string Name { get; }
        string Author { get; }
        string Version { get; }
        string Type { get; }
        string Cmd { get; }
        string Description { get; }
        int ActionCount { get; set; }

        int Execute();
        int Execute(string param);
        int Execute(string[] subInCmd);
        int Execute(List<string> subInCmd);
    }
}