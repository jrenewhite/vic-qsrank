using System;
using System.Reflection;
using System.Runtime.Loader;

namespace vic_qsrank.Core
{
    /// <summary>
    /// Plugin Load Context:
    /// By using the <see cref="AssemblyDependencyResolver"/> type and a custom <see cref="AssemblyLoadContext"/>, "plugins" can be loaded with assembly dependencies
    /// </summary>
    class PluginLoadContext : AssemblyLoadContext
    {
        private AssemblyDependencyResolver assemblyDependencyResolver;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pluginPath"></param>
        public PluginLoadContext(string pluginPath)
        {
            assemblyDependencyResolver = new AssemblyDependencyResolver(pluginPath);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <returns></returns>
        protected override Assembly Load(AssemblyName assemblyName)
        {
            string assemblyPath = assemblyDependencyResolver.ResolveAssemblyToPath(assemblyName);
            if (assemblyPath != null)
            {
                return LoadFromAssemblyPath(assemblyPath);
            }

            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unmanagedDllName"></param>
        /// <returns></returns>
        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            string libraryPath = assemblyDependencyResolver.ResolveUnmanagedDllToPath(unmanagedDllName);
            if (libraryPath != null)
            {
                return LoadUnmanagedDllFromPath(libraryPath);
            }

            return IntPtr.Zero;
        }
    }
}
