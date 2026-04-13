using System.Runtime.Loader;

using DoubleCorvid.NEST.Plugin.Exceptions;

namespace DoubleCorvid.NEST.Plugin.Load;

public class PluginLoader (IPluginLoadContextBuilder builder) {
    private readonly IPluginLoadContextBuilder _builder = builder;

    public IPlugin LoadPlugin (string pluginPath) {
        var loadContext = new AssemblyLoadContext (pluginPath);

        var asm = loadContext.LoadFromAssemblyPath (pluginPath);

        var pluginTypes = asm.GetTypes ().Where (t => typeof (IPlugin).IsAssignableFrom (t)).ToList();

        if (pluginTypes.Count > 1) {
            throw new TooManyPluginsException ($"Expected to find 1 assembly, found {pluginTypes.Count}.");
        }

        if (pluginTypes.Count == 0) {
            throw new NoPluginFoundException ($"Expected to find 1 assembly, found none.");
        }

        return (IPlugin) (Activator.CreateInstance (pluginTypes [0]) 
                                                    ?? throw new FailedToCreatePluginInstanceException ("Failed to create an instance of the plugin definition."));
    }

    public List<IPlugin> LoadPlugins (List<string> pluginPaths) {
        var plugins = new List<IPlugin> ();

        foreach (var pluginPath in pluginPaths) {
            plugins.Add (LoadPlugin (pluginPath));
        }

        return plugins;
    }
}
