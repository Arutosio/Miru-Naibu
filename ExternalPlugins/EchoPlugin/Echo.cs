using PluginBase;
using System;
using System.Collections.Generic;

namespace Echo
{
    public class Echo : ICommand
    {
        public string Name { get => "Echo"; }
        public string Author { get => "Arutosio"; }
        public string Type { get => "Plugin"; }
        public string Cmd { get => "echo"; }
        public string Description { get => "Echo command print that you write"; }
        public int ActionCount { get => 0; set => ActionCount = 0; }

        public int Execute()
        {
            Console.Write("Write: ");
            Console.WriteLine(Console.ReadLine());
            return 0;
        }

        public int Execute(string param)
        {
            Console.WriteLine(param);
            return 0;
        }

        public int Execute(string[] subInCmd)
        {
            int num = 0;
            string res = "";
            foreach (string str in subInCmd)
            {
                res += $"{str} ";
            }
            try
            {
                num = int.Parse(subInCmd[subInCmd.Length - 1]);
                //cmdParam = cmdParam.
            } catch
            {
                num = - 1;
            }
            if (num >= 2)
            {
                for (int i = 0; i < num; i++)
                {
                    Console.WriteLine(res);
                }
            }
            else { Console.WriteLine(res); }
            return 0;
        }

        public int Execute(List<string> subInCmd)
        {
            int num = 0;
            string res = "";
            foreach (string str in subInCmd)
            {
                res += $"{str} ";
            }
            try
            {
                num = int.Parse(subInCmd[subInCmd.Count]);
                //cmdParam = cmdParam.
            } catch
            {
                num = - 1;
            }
            if (num >= 2)
            {
                for (int i = 0; i < num; i++)
                {
                    Console.WriteLine(res);
                }
            }
            else { Console.WriteLine(res); }
            return 0;
        }
    }
}
