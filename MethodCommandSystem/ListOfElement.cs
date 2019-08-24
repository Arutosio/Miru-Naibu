using System;
using System.Collections.Generic;
using System.IO;
using Miru_Naibu.Entities;
using Miru_Naibu.MethodCommandSystem;

namespace Miru_Naibu.MethodCommandSystem
{
    public sealed class ListOfElement
    {
        public static void  ListSwitch(List<string> subcmdList) {
            switch (subcmdList[0]) {
                case "default":
                    Console.WriteLine("TO DO CASE 0 lS");
                break;
                case "files":
                    ListOfFiles();
                break;
                case "dir":
                    ListOfDirectory();
                break;
                default:
                    Console.WriteLine("Error with the properti {0}",subcmdList[0]);
                break;
            }
        }

        private static void ListOfDirectory()
        {
            string[] listOfFolders = Directory.GetDirectories(MiruNaibu.GetMiruNaibuInstance.CurrentDirectory.FullName, "",SearchOption.AllDirectories);
            for (int i = 0; i < listOfFolders.Length; i++) {
                Console.WriteLine("Num: {0} - Folder Name: {1}", i, Path.GetDirectoryName(listOfFolders[i]));
            }
        }

        internal static void ListOfFiles()
        {
            string[] listOfFiles = Directory.GetFiles(MiruNaibu.GetMiruNaibuInstance.CurrentDirectory.FullName, "*");
            for (int i = 0; i < listOfFiles.Length; i++) {
                Console.WriteLine("Num: {0} - File Name: {1} - DateCreation {2} ", i, Path.GetFileName(listOfFiles[i]), File.GetLastWriteTime(listOfFiles[i]).ToString());
            }
        }
    }
}