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

        public int Execute(string param)
        {
            Console.WriteLine("Hello ! WITH param: "+param);
            return 0;
        }

        public int Execute(string[] subInCmd)
        {
            Console.Write("Hello ! WITH subInCmd: ");
            for (int i = 0; i < subInCmd.Length; i++)
            {
                Console.Write(subInCmd[i]+", ");
            }
            Console.WriteLine();
            return 0;
        }
    }
}