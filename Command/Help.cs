using System;

namespace Miru_Naibu.Command
{
    public class Help : Command
    {
        public Help(string name, string type, string cmd, string description) : base(name, type, cmd, description)
        {
            
        }
        public void CmdInfo(Command cmd) {
            Console.WriteLine("  Name: "+cmd.Name);
            Console.WriteLine("  Type: "+cmd.Type);
            Console.WriteLine("  Command: "+cmd.Cmd);
            Console.WriteLine("  Description: "+cmd.Description);
        }
    }
}