namespace Miru_Naibu.Command
{
    public abstract class Command
    {
        private Command() {}
        public Command(string name, string type, string cmd,string description) {
            Name = name;
            Type = type;
            Cmd = cmd;
            Description = description;
        }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Cmd { get; set; }
        public string Description { get; set; }
    }
}