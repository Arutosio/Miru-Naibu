using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using PluginBase;

namespace Miru_Naibu.Library
{
    public class PluginManager 
    {
        private DirectoryInfo pathFolder;
        private string folderName;
        public DirectoryInfo fullPathFolder;
        public string[] pluginsPaths;

        public DirectoryInfo PathFolder { 
            get { return this.pathFolder; } 
            set { if(value.Exists) this.pathFolder = value; else throw new AruLibException($"This directory: {value.FullName} \r\n not exist."); } 
        }
        public string FolderName {
            get { return this.folderName; } 
            set { if(!string.IsNullOrWhiteSpace(value)) this.folderName = value; else throw new AruLibException($"This folder name {value} is not a valid name."); }
        }
        public DirectoryInfo FullPathFolder { 
            get { return this.fullPathFolder; }
            set { this.fullPathFolder = value; }
            //set { if(value.Exists) FullPathFolder = value; else throw new AruLibException($"This folder {value.FullName} does not exist."); }
        }
        public string[] PluginsPaths { 
            get { return this.pluginsPaths; }
            set { this.pluginsPaths = value; }
        }
        public PluginManager(DirectoryInfo pathFolder, string folderName)
        {
            PathFolder = pathFolder;
            FolderName = folderName;
            FullPathFolder = new DirectoryInfo(Path.Combine(PathFolder.FullName, FolderName));
            PluginsPaths = GetPlugins(FullPathFolder);
        }
        
        // public bool IsValidFilename(string testName)
        // {
        //     Regex containsABadCharacter = new Regex("[" + Regex.Escape(System.IO.Path.InvalidPathChars) + "]");
        //     if (containsABadCharacter.IsMatch(testName) { return false; };
        //     // other checks for UNC, drive-path format, etc
        //     return true;
        // }
        public static string[] GetPlugins(DirectoryInfo fullPathFolder)
        {
            string[] ret = null;
            if(fullPathFolder.Exists)
                ret = Directory.GetFiles(fullPathFolder.FullName, "*.dll");
            else 
                CreatePluginsFolder(fullPathFolder);
            return ret;
        }
        public IEnumerable<ICommand> ReloadPlugins(string[] pluginPaths) 
        {
            IEnumerable<ICommand> commands;
            commands = pluginPaths.SelectMany(pluginPath => {
                Assembly pluginAssembly = LoadPlugin(pluginPath);
                    return CreateCommands(pluginAssembly);
            }).ToList();
            return commands;
        }
        public static Assembly LoadPlugin(string relativePath) {
            // Navigate up to the solution root 
            string root = Path.GetFullPath(Path.Combine(
                Path.GetDirectoryName(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(
                            Path.GetDirectoryName(
                                Path.GetDirectoryName(typeof(Program).Assembly.Location)))))));
            string pluginLocation = Path.GetFullPath(Path.Combine(root, relativePath.Replace('\\', Path.DirectorySeparatorChar)));
            Console.WriteLine($"Loading commands from: {pluginLocation}");
            PluginLoadContext loadContext = new PluginLoadContext(pluginLocation);
            return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
        }
        public static IEnumerable<ICommand> CreateCommands(Assembly assembly) {
            int count = 0;
            foreach (Type type in assembly.GetTypes()) {
                if (typeof(ICommand).IsAssignableFrom(type)) {
                    ICommand result = Activator.CreateInstance(type) as ICommand;
                    if (result != null) {
                        count++;
                        yield return result;
                    }
                }
            }
            if (count == 0) {
                string availableTypes = string.Join(",", assembly.GetTypes().Select(t => t.FullName));
                throw new ApplicationException(
                    $"Can't find any type which implements ICommand in {assembly} from {assembly.Location}.\n" +
                    $"Available types: {availableTypes}"
                );
            }
        }
        public static void CreatePluginsFolder(DirectoryInfo fullPathFolder) 
        {
            if(fullPathFolder.Exists)
                Console.WriteLine("The plugins folder already exist.");
            else 
                Directory.CreateDirectory(fullPathFolder.FullName);
        }
        // public static void LoadPlugins(string pathDir) {
        //     if(!IsDirectoryEmpty(pathDir)) {
        //         string[] allDll = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Plugins"), "*.dll");
        //         //PrintFilesDir(allDll);
        //         List<Assembly> pluginsAssembly = new List<Assembly>();
        //         //IEnumerable<ICommand> cmds = new IEnumerable<ICommand>();
        //         foreach (string  pahtFile in allDll)
        //         {
        //             Console.WriteLine($"Loading commands from: {pahtFile}");
        //             PluginLoadContext loadContext = new PluginLoadContext(pahtFile);
        //             pluginsAssembly.Add(loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pahtFile))));
        //             Console.WriteLine("ASSEMBLY: "+loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pahtFile)))
        //             .FullName);
        //         }
        //         Console.WriteLine("Assemble aggiunto alla liosta");          
        //     }
        // }
    }
}