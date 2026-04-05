using DoubleCorvid.NEST.Plugin.Exceptions;

namespace DoubleCorvid.NEST.Plugin.Load;

public class PluginLoader (IPluginLoadContextBuilder builder) {
    private readonly IPluginLoadContextBuilder _builder = builder;

    public IPlugin LoadPlugin (string pluginPath) {
        var loadContext = _builder.WithPluginPath (pluginPath).Build ();

        var asm = loadContext.LoadFromAssemblyPath (pluginPath);

        var plugins = asm.GetTypes ().Where (t => t.IsAssignableTo (typeof (IPlugin))).ToList ();

        if (plugins.Count > 1) {
            throw new TooManyPluginsException ($"Expected to find 1 assembly, found {plugins.Count}.");
        }

        if (plugins.Count == 0) {
            throw new NoPluginFoundException ($"Expected to find 1 assembly, found none.");
        }

        return (IPlugin) (Activator.CreateInstance (plugins [0]) 
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
