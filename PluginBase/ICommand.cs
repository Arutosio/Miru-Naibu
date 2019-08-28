using System;
namespace PluginBase
{
    public interface ICommand {
        string Name { get; }
        string Author { get; }
        string Description { get; }
        int Execute();
    }
}