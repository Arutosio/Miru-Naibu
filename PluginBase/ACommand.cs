
using System;
using System.Collections.Generic;

namespace PluginBase
{
    public abstract class ACommand
    {

        public string Name { get; set; } = "Name is None";
        public string Author { get; set; } = "Author is None";
        public string Type { get; set; } = "Type is None";  
        public string Cmd { get; set; } = "Cmd is None";
        public string Description { get; set; } = "Desciption is None";
        public int ActionCount { get; set; } = 0;

        public virtual void OnJoin()
        {
            this.ActionCount = 0;
            //throw new NotImplementedException();
        }
        public virtual void Switch(List<string> cmdParam)
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
        }
        protected virtual int Execute() {
            Console.WriteLine("ACommand Execute");
            return 0;
        }
        protected virtual int Execute(string param) {
            Console.WriteLine($"ACommand Execute(string {param})");
            return 0;
        }
        protected virtual int Execute(string[] subInCmd) {
            Console.WriteLine($"ACommand Execute(string[] {subInCmd.ToString()}");
            return 0;
        }
        protected virtual void OnExit() {
            Console.WriteLine("ACommand OnExit()");

        }
    }
}