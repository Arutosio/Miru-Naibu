using System;
using PluginBase;

namespace HelloPlugin
{
    public class HelloCommand : ICommand
    {
        public string Name { get => "hello"; }
        public string Description { get => "Displays hello message."; }
        public string Author { get => "Arutosio"; }

        public int Execute() {
            Console.WriteLine("Hello !!!");
            return 0;
        }
    }
}