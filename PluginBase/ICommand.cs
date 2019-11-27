using System;
namespace PluginBase
{
    public interface ICommand {
        string Name { get; }
        string Author { get; }
        string Cmd { get; }
        string Description { get; }
        int ActionCount { get; set; }
        void OnJoin();
        int Execute();
        int Execute(string param);
        int Execute(string[] subInCmd);
        void OnExit();
    }
}