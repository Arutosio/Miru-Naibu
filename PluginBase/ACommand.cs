
using System;
using System.Collections.Generic;

namespace PluginBase
{
    public abstract class ACommand
    {

        public abstract string Name { get; set; }
        public abstract string Author { get; set; }
        public abstract string Type { get; set; }
        public abstract string Cmd { get; set; }
        public abstract string Description { get; set; }
        protected int ActionCount { get; set; } = 0;

        public ACommand() { }

        public abstract void OnJoin(List<string> cmdParam);
        #region
        /*
        public virtual void OnJoin(List<string> cmdParam)
        {
            this.ActionCount = 0;
            //throw new NotImplementedException();
        }
        */
        #endregion
        protected abstract void Switch(List<string> cmdParam);
        #region
        /*
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
        */
        #endregion
        protected abstract int Execute();
        #region
        /*
        #endregion
        protected virtual int Execute() {
            Console.WriteLine("ICommand Execute");
            return 0;
        }
        */
        #endregion
        protected abstract int Execute(string param);
        #region
        /*
        protected virtual int Execute(string param) {
            Console.WriteLine($"ICommand Execute(string {param})");
            return 0;
        }
        */
        #endregion
        protected abstract int Execute(string[] subInCmd);
        #region
        /*
        protected virtual int Execute(string[] subInCmd) {
            Console.WriteLine($"ICommand Execute(string[] {subInCmd.ToString()}");
            return 0;
        }
        */
        #endregion
        protected abstract void OnExit();
        #region
        /*
        protected virtual void OnExit() {
            Console.WriteLine("ICommand OnExit()");
        }
        */
        #endregion
    }
}