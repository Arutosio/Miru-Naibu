﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using Miru_Naibu.Entities;
using Miru_Naibu.Library;
using PluginBase;
using static System.ConsoleColor;
namespace Miru_Naibu
{
    class Program
    {//Command to make a release: dotnet publish -c Release -r win10-x64 OR linux-x64
        static void Main(string[] args)
        {
            try {
                if (args.Length == 1 && args[0] == "/d") {
                    Console.WriteLine("Waiting for any key...");
                    Console.ReadLine();
                }
                //START LOAD commands from plugins.
                string[] pluginPaths = new string[] {
                    // Paths to plugins to load.
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
                throw new NotImplementedException();
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
                        $"Available types: {availableTypes}");
                }
            }

            /*
            //Run FASE - Checking
            MiruNaibu terminal = MiruNaibu.GetMiruNaibuInstance;
            //Start
            string cmd = "";
            do {
            terminal.ReadyString();
            cmd = Console.ReadLine();
            if(cmd.ToLower().Replace(" ","").Equals("exit")) { break; }
            else if (!string.IsNullOrEmpty(cmd) && !string.IsNullOrWhiteSpace(cmd)){
                terminal.RunCommand(Command.CmdSplit(cmd)); }
            } while (true);
             */
        }
    }
}
