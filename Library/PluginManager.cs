using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using PluginBase;

namespace Miru_Naibu.Library
{
    public static class PluginManager
    {
        public static void Start(string[] args) {
            try {
                if (args.Length == 1 && args[0] == "/d") {
                    Console.WriteLine("Waiting for any key...");
                    Console.ReadLine();
                }
                //START LOAD commands from plugins.
                Console.WriteLine("");
                string[] pluginPaths = new string[] {
                    // Paths to plugins to load.
                    //@"SystemPlugin\HelloPlugin\bin\Debug\netcoreapp3.0\HelloPlugin.dll",
                    //@"JsonPlugin\bin\Debug\netcoreapp3.0\JsonPlugin.dll",
                    @"SystemPlugin\XcopyablePlugin\bin\Debug\netcoreapp3.0\XcopyablePlugin.dll",
                    //@"OldJsonPlugin\bin\Debug\netcoreapp2.1\OldJsonPlugin.dll",
                    //@"FrenchPlugin\bin\Debug\netcoreapp2.1\FrenchPlugin.dll",
                    //@"UVPlugin\bin\Debug\netcoreapp2.1\UVPlugin.dll",
                };

                IEnumerable<ICommand> commands = pluginPaths.SelectMany(pluginPath => {
                    Assembly pluginAssembly = LoadPlugin(pluginPath);
                    return CreateCommands(pluginAssembly);
                }).ToList();
                //END LOAD commands
                if (args.Length == 0) {
                    Console.WriteLine("Commands: ");
                    //START Output the loaded commands.
                    foreach (ICommand command in commands) {
                        Console.WriteLine($"{command.Name}\t - {command.Author} - {command.Description}");
                    } //END Output load commands.
                }
                else {
                    foreach (string commandName in args) {
                        Console.WriteLine($"-- {commandName} --");
                        // Execute the command with the name passed as an argument.
                        ICommand command = commands.FirstOrDefault(c => c.Name == commandName);
                        if (command == null) {
                            Console.WriteLine("No such command is known.");
                            return;
                        }
                        command.Execute();
                        Console.WriteLine();
                    }
                }
            } catch (Exception ex) { Console.WriteLine(ex); }

            static Assembly LoadPlugin(string relativePath) {
                // Navigate up to the solution root 
                string root = Path.GetFullPath(Path.Combine(
                    Path.GetDirectoryName(
                        Path.GetDirectoryName(
                            Path.GetDirectoryName(
                                Path.GetDirectoryName(
                                    Path.GetDirectoryName(typeof(Program).Assembly.Location)))))));
                string pluginLocation = Path.GetFullPath(Path.Combine(root, relativePath.Replace('\\', Path.DirectorySeparatorChar)));
                /*
                Console.WriteLine(Path.Combine(Directory.GetCurrentDirectory(), relativePath));
                string pluginLocation = Path.Combine(Directory.GetCurrentDirectory(), relativePath);
                */
                Console.WriteLine($"Loading commands from: {pluginLocation}");
                PluginLoadContext loadContext = new PluginLoadContext(pluginLocation);
                return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
            }

            static IEnumerable<ICommand> CreateCommands(Assembly assembly) {
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
        }
    }
}