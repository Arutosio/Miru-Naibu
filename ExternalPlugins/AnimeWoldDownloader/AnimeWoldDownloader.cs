using PluginBase;
using System;
using System.Collections.Generic;
using Miru_Naibu.Library;

namespace AnimeWoldDownloader
{
    public class AnimeWoldDownloader : ICommand
    {
        public string Name { get => "Multi File Downloader By Single URL"; set => throw new NotImplementedException(); }
        public string Author { get => "Arutosio"; set => throw new NotImplementedException(); }
        public string Type { get => "Plugin"; set => throw new NotImplementedException(); }
        public string Cmd { get => "mfd"; set => throw new NotImplementedException(); }
        public string Description { get => "Multi File Downloader By Single URL"; set => throw new NotImplementedException(); }
        public int ActionCount { get => 0; set => ActionCount = value; }

        public int Execute()
        {
            Console.WriteLine("FileDownloader Execute()");
            return 0;
        }

        public int Execute(string param)
        {
            throw new NotImplementedException();
        }

        public int Execute(string[] subInCmd)
        {
            throw new NotImplementedException();
        }

        public int Execute(List<string> subInCmd)
        {
            throw new NotImplementedException();
        }
    }
}
