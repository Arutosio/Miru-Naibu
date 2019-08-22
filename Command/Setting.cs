namespace Miru_Naibu.Command
{
    public class Setting : Command
    {
    public string x;
        public Setting(string name, string type, string cmd, string description) : base(name, type, cmd, description)
        {
        }
    }
}