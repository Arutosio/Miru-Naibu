using System;
using System.Collections.Generic;
using System.IO;
using Miru_Naibu.Entities;

namespace Miru_Naibu.Library
{
    public static class DirManager
    {
        public static string ChangeDir(string strPath) 
        {
            DirectoryInfo dir = new DirectoryInfo(strPath);
            if(Directory.Exists(dir.FullName))
                return dir.FullName;
            throw new Exception();
        }
        public static DirectoryInfo GoUnderDirectory(DirectoryInfo strRoot) 
        {
            return strRoot = strRoot.Parent;
        }
        public static DirectoryInfo GoSubDirectory(string folderName) 
        {
            
            if(Path.IsPathRooted(folderName) && Directory.Exists(folderName))
            {
                return new DirectoryInfo(folderName);
            }
            else if (Directory.Exists(Path.Combine(folderName, folderName)))
            {
                return new DirectoryInfo(folderName);
            } 
            else { throw new AruLibException($"The folder \"{folderName}\" does not exits in the current directory."); }
        }
        public static bool CreateFolder(string dirFolder) 
        {
            if (!Directory.Exists(dirFolder))  
            {  
                Directory.CreateDirectory(dirFolder);
                return true; 
            }
            return false; 
        }
        public static bool DeleteFolder(string dirFolder) 
        {
            if (Directory.Exists(dirFolder))  
            {  
                Directory.Delete(dirFolder);
                return true;
            }
            return false;
        }
        public static bool MoveFolder(string sourceDirName, string destDirName)
        {
            try  
            {  
                Directory.Move(sourceDirName, destDirName);  
            }  
            catch (IOException ex)  
            {  
                throw ex;  
            } 
            return true;
        }
    }
}