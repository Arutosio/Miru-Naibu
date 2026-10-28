using System;
using System.IO;

namespace Miru_Naibu.Library
{
    public class Logger
    {
        private string fileName;
        private FileInfo fileLog;
        public string FileName 
        { 
            get { return this.fileName; }
            set { if(!string.IsNullOrWhiteSpace(value)) this.fileName = $"{value}_{DateTime.Now.ToString("yyyy/MM/dd")}"; else throw new AruLibException("The name can not be null."); }
        }
        public FileInfo FileLog 
        {
            get { return this.fileLog; }
            set { if(value != null) this.fileLog = value; }
        }
        public Logger(string filePath)
        {
            FileLog = new FileInfo(filePath);
        }
        public static FileStream CreateFileLog(string fileName, DirectoryInfo pathFolder)
        {
            FileStream ret = null;
            if(pathFolder.Exists)
            {
                string filePath = Path.Combine(pathFolder.FullName, fileName);
                if(!File.Exists(filePath))
                { // Create a new file 
                    ret = File.Create(filePath);
                } 
                else 
                {
                    ret = new FileStream(filePath, FileMode.Open, FileAccess.Write);
                } 
            }
            return ret;
        }
    }
}