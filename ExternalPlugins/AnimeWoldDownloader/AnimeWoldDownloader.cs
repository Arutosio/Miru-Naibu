using PluginBase;
using System;
using System.Collections.Generic;
using Miru_Naibu.Library;

namespace AnimeWoldDownloader
{
    public class AnimeWoldDownloader : ACommand
    {
         public override string Name { get; set; } = "AnimeWoldDownloader";
         public override string Author { get; set; } = "Arutosio";
         public override string Type { get; set; } = "Plugin";
         public override string Cmd { get; set; } = "AnimeWoldDownloader";
         public override string Description { get; set; } = "AnimeWoldDownloader command print that you write";

        public override void OnJoin(List<string> cmdParam)
        {
            Switch(cmdParam);
            OnExit();
        }
        protected override void Switch(List<string> cmdParam)
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
                    Execute(cmdParam.ToArray());
                    break;
            }
        }
        protected override int Execute()
        {
            //Console.Write("Write: ");
            ColorLine.WriteC("Write: ",ConsoleColor.Yellow);
            Console.WriteLine(Console.ReadLine());
            return 0;
        }

        protected override int Execute(string param)
        {
            Console.WriteLine(param);
            return 0;
        }

        protected override int Execute(string[] cmdParam)
        {
            int num = 0;
            string res = "";
            foreach (string str in cmdParam)
            {
                res += $"{str} ";
            }
            try
            {
                num = int.Parse(cmdParam[cmdParam.Length - 1]);
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

        protected override void OnExit()
        {
            ActionCount = 0;
        }
    }
}
