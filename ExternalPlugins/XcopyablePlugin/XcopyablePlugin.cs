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

        public int Execute(string param)
        {
            Console.Write("Hello ! WITH subInCmd: "+param);
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