using System;
using System.Collections.Generic;
using System.IO;

namespace Miru_Naibu.MethodCommandSystem
{
    public sealed class ChangeDirectory
    {
        public static DirectoryInfo CurrentDirectory { get; set; } = new DirectoryInfo(Directory.GetCurrentDirectory());
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
            CurrentDirectory = Directory.GetParent(CurrentDirectory.FullName);
        }
        internal static void GoUpDirectory(string folderName) {
            if (Directory.Exists(folderName)) {
                CurrentDirectory = new DirectoryInfo(folderName); 
            } else if(Directory.Exists(Path.Combine(CurrentDirectory.FullName, folderName))) {
                CurrentDirectory = new DirectoryInfo(Path.Combine(CurrentDirectory.FullName, folderName)); 
            } else { Console.WriteLine("The folder \"{0}\" does not exits in the current directory.", folderName); }
        }
    }
}