using System;
using System.Collections.Generic;
using PluginBase;

namespace XcopyablePlugin
{
    public class XcopyablePlugin : ACommand
    {
        public XcopyablePlugin()
        {
            this.Name = "XCopy";
            this.Author = "Arutosio";
            this.Type = "App";  
            this.Cmd = "xcopy";
            this.Description = "Displays xcopy message.";
            this.ActionCount = 0;
        }
        public virtual void OnJoin()
        {
            this.ActionCount = 0;
            //throw new NotImplementedException();
        }
        public override void Switch(List<string> cmdParam)
        {
            switch (cmdParam.Count)
            {
                case 0:
                    Execute();
                    break;
                case 1:
                    Execute(cmdParam[0]);
                    break;
                default:
                    Console.WriteLine("Param not found");
                    break;
            }
            OnExit();
        }

        protected override int Execute() {
            Console.WriteLine("Xcopy !!!");
            return 0;
        }

        protected override int Execute(string param)
        {
            Console.WriteLine($"Hello ! WITH subInCmd: {param}");
            return 0;
        }

        protected override int Execute(string[] subInCmd)
        {
            Console.Write("Hello ! WITH subInCmd: ");
            for (int i = 0; i < subInCmd.Length; i++)
            {
                Console.Write(subInCmd[i]+", ");
            }
            Console.WriteLine();
            return 0;
        }

        protected override void OnExit()
        {
            Console.WriteLine("Execute({0}) finish.",Name);
        }
    }
}