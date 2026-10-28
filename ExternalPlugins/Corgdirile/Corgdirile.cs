using PluginBase;
using System;
using System.Collections.Generic;

namespace Corgdirile
{
    public class Corgdirile : ICommand
    {
        public string Name { get => "Corgdirile"; }
        public string Author { get => "Arutosio"; }
        public string Version { get => "0.0.1.0"; }
        public string Type { get => "Plugin"; }
        public string Cmd { get => "corgdirile"; }
        public string Description { get => "Corgdirile is a organize your file."; }
        public int ActionCount { get => 0; set => ActionCount = 0; }

        public int Execute()
        {
            Console.WriteLine("  ---        <-_ Welcome Corgdirile by Arutosio_->        ---  ");
            Console.Write("  ~  "); Console.Write("For more info: https://github.com/Arutosio/Corgdirile"); Console.WriteLine("  ~  ");
            return 0;
        }

        public int Execute(string param)
        {
            string[] values = param.Split(" loop: ");
            string msg = values[0];
            uint loop;
            
            if (values.Length == 2)
            {
                try {
                    loop = uint.Parse(values[1]);
                } catch (Exception ex) { throw ex; }
                for (int i = 1; i <= loop; i++)
                {
                    Console.Write(string.Concat(msg, ' '));
                }
            }
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
