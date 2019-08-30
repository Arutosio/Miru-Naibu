using System;
using PluginBase;

namespace XcopyablePlugin
{
    public class XcopyablePlugin : ICommand {
        public string Name { get => "XCopy"; }
        public string Author { get => "Arutosio"; }
        public string Cmd { get => "xcopy"; }
        public string Description { get => "Displays xcopy message."; }


        public int Execute() {
            Console.WriteLine("Xcopy !!!");
            return 0;
        }
    }
}