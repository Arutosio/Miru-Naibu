using System;
using PluginBase;

namespace XcopyablePlugin
{
    public class XcopyablePlugin : ICommand {
        public string Name { get => "xcopy"; }
        public string Description { get => "Displays xcopy message."; }
        public string Author { get => "Arutosio"; }

        public int Execute() {
            Console.WriteLine("Xcopy !!!");
            return 0;
        }
    }
}