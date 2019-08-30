using System;
using PluginBase;

namespace HelloPlugin
{
    public class HelloCommand : ICommand
    {
        public string Name { get => "Hello"; }
        public string Author { get => "Arutosio"; }
        public string Cmd { get => "hello"; }
        public string Description { get => "Displays hello message."; }

        public int Execute() {
            Console.WriteLine("Hello !!!");
            return 0;
        }
    }
}