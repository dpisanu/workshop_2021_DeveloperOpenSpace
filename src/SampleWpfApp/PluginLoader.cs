using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using Common.Plugin;

namespace SampleWpfApp
{
    public static class PluginLoader
    {
        public static IEnumerable<IPlugin> LoadPlugins()
        {
            var plugins = new List<IPlugin>();
            var pluginsPaths = GetAssemblyPathForPlugins();
            foreach (var path in pluginsPaths)
            {
                var assembly = Assembly.LoadFile(path);
                foreach (var type in assembly.DefinedTypes)
                {
                    if (typeof(IPlugin).IsAssignableFrom(type))
                    {
                        var instance = (IPlugin)Activator.CreateInstance(type);
                        plugins.Add(instance);
                    }
                }
            }
            return plugins;
        }

        private static IEnumerable<string> GetAssemblyPathForPlugins()
        {
            var currentAssemblyDirectory = typeof(App).Assembly.GetAssemblyDirectory();
            var plugins = Directory.EnumerateFiles(currentAssemblyDirectory, "*.dll", SearchOption.TopDirectoryOnly)
                .Where(x => x.Contains("Plugins.", StringComparison.OrdinalIgnoreCase));

            return plugins;
        }

        private static string GetAssemblyDirectory(this Assembly assembly)
        {
            var codeBase = assembly.CodeBase;
            var uri = new UriBuilder(codeBase);
            var path = Uri.UnescapeDataString(uri.Path);

            return Path.GetDirectoryName(path);
        }
    }
}