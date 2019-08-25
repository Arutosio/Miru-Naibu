using System;
using System.Collections.Generic;
using System.IO;
using Miru_Naibu.Entities;

namespace Miru_Naibu.MethodCommandSystem
{
    public sealed class ChangeDirectory
    {
        public static void ChangeDirectorySwitch(List<string> subCmdList) {          
            switch (subCmdList.Count) {
                case 1:
                    if(subCmdList[0].Equals("..")) { GoSubDirectory(); }
                    else { GoUpDirectory(subCmdList[0]); }
                break;
                default:
                    if (subCmdList.Count<=0) {
                        Console.WriteLine("The comand \"cd\" need a parameter.");
                    } else { Console.WriteLine($"Parameter \"{subCmdList[0]}\" not found."); }
                break;
            }
        }
        internal static void GoSubDirectory() {
            MiruNaibu.GetMiruNaibuInstance.CurrentDirectory = new DirectoryInfo(Directory.GetParent(MiruNaibu.GetMiruNaibuInstance.CurrentDirectory.FullName).FullName);
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