using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using PluginBase;

namespace Miru_Naibu.Library
{
    public static class PluginManager {
        public static string[] pluginPaths = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Plugins"), "*.dll");
        public static IEnumerable<ICommand> commands;
        public static void ReloadPlugins() {
            commands = pluginPaths.SelectMany(pluginPath => {
                Assembly pluginAssembly = LoadPlugin(pluginPath);
                return CreateCommands(pluginAssembly);
            }).ToList();
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
        public static bool CheckDirPlugins() {
            return Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "Plugins"));
        }
        public static bool IsDirectoryEmpty() {
            return !Directory.EnumerateFileSystemEntries(Path.Combine(Directory.GetCurrentDirectory(), "Plugins")).Any();
        }
        public static void Install() {
            Console.WriteLine(Directory.GetCurrentDirectory());
            if(CheckDirPlugins()) {
                Console.WriteLine("La cartella Plugins esiste di gia.");;
            } else { Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "Plugins"));}
        }
        public static void LoadPlugins() {
            if(!IsDirectoryEmpty()) {
                string[] allDll = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "Plugins"), "*.dll");
                //PrintFilesDir(allDll);
                List<Assembly> pluginsAssembly = new List<Assembly>();
                //IEnumerable<ICommand> cmds = new IEnumerable<ICommand>();
                foreach (string  pahtFile in allDll)
                {
                    Console.WriteLine($"Loading commands from: {pahtFile}");
                    PluginLoadContext loadContext = new PluginLoadContext(pahtFile);
                    pluginsAssembly.Add(loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pahtFile))));
                    Console.WriteLine("ASSEMBLY: "+loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pahtFile)))
                    .FullName);
                }
                Console.WriteLine("Assemble aggiunto alla liosta");          
            }
        }
    }
}