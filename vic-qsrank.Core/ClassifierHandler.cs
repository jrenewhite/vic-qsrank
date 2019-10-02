using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using vic_qsrank.ClassifierBase;
using Console = Colorful.Console;

namespace vic_qsrank.Core
{
    public class ClassifierHandler
    {

        public static IEnumerable<IClassifier> GetCommands(string pluginDirectory)
        {
            IEnumerable<IClassifier> commands = GetPluginPaths(pluginDirectory).SelectMany(pluginPath =>
            {
                Assembly pluginAssembly = LoadPlugin(pluginPath);
                return CreateCommands(pluginAssembly);
            }).ToList();

            return null;
        }
        static string[] GetPluginPaths(string pluginDirectory)
        {

            if (Directory.Exists(pluginDirectory))
            {
                return Directory.EnumerateFiles(pluginDirectory, "*.dll", SearchOption.AllDirectories).ToArray();
            }

            return new string[0];
        }

        static Assembly LoadPlugin(string relativePath)
        {
            //// Navigate up to the solution root
            //string root = Path.GetFullPath(Path.Combine(
            //    Path.GetDirectoryName(
            //        Path.GetDirectoryName(
            //            Path.GetDirectoryName(
            //                Path.GetDirectoryName(
            //                    Path.GetDirectoryName(typeof(ClassifierHandler).Assembly.Location)))))));

            //string pluginLocation = Path.GetFullPath(Path.Combine(root, relativePath.Replace('\\', Path.DirectorySeparatorChar)));
            string pluginLocation = relativePath;
            Console.WriteLine($"Loading commands from: {pluginLocation}");
            PluginLoadContext loadContext = new PluginLoadContext(pluginLocation);
            return loadContext.LoadFromAssemblyName(new AssemblyName(Path.GetFileNameWithoutExtension(pluginLocation)));
        }

        static IEnumerable<IClassifier> CreateCommands(Assembly assembly)
        {
            int count = 0;

            foreach (Type type in assembly.GetTypes())
            {
                if (typeof(IClassifier).IsAssignableFrom(type))
                {
                    IClassifier result = Activator.CreateInstance(type) as IClassifier;
                    if (result != null)
                    {
                        count++;
                        yield return result;
                    }
                }
            }

            if (count == 0)
            {
                string availableTypes = string.Join(",", assembly.GetTypes().Select(t => t.FullName));
                throw new ApplicationException(
                    $"Can't find any type which implements IClassifier in {assembly} from {assembly.Location}.\n" +
                    $"Available types: {availableTypes}");
            }
        }

    }
}
