using System;
using System.Collections.Generic;
using System.IO;
using Miru_Naibu.Entities;

namespace Miru_Naibu.MethodCommandSystem
{
    public sealed class ChangeDirectory
    {
        public static void ChangeDirectorySwitch(List<string> subcmdList) {
            switch (subcmdList.Count) {
                case 1:
                    if(subcmdList[0].Equals("..")) { GoSubDirectory(); }
                    else { GoUpDirectory(subcmdList[0]); }
                break;
                default:
                    Console.WriteLine("Error with the properti {0}",subcmdList[0]);
                break;
            }
        }
        internal static void GoSubDirectory() {
            MiruNaibu.GetMiruNaibuInstance.CurrentDirectory = Directory.GetParent(MiruNaibu.GetMiruNaibuInstance.CurrentDirectory.FullName);
        }
        internal static void GoUpDirectory(string folderName) {
            if (Directory.Exists(folderName)) {
                MiruNaibu.GetMiruNaibuInstance.CurrentDirectory = new DirectoryInfo(folderName); 
            } else if(Directory.Exists(Path.Combine(MiruNaibu.GetMiruNaibuInstance.CurrentDirectory.FullName, folderName))) {
                MiruNaibu.GetMiruNaibuInstance.CurrentDirectory = new DirectoryInfo(Path.Combine(MiruNaibu.GetMiruNaibuInstance.CurrentDirectory.FullName, folderName)); 
            } else { Console.WriteLine("The folder \"{0}\" does not exits in the current directory.", folderName); }
        }
    }
}