using DoubleCorvid.NEST.Plugin.Exceptions;
using DoubleCorvid.NEST.Plugin.Load;

namespace DoubleCorvid.NEST.Plugin.Manager;

public class PluginManager : IPluginManager {
    private readonly PluginManagerConfig _config;

    private readonly Dictionary<Guid, IPlugin> _plugins = [];

    public IReadOnlyDictionary<Guid, IPlugin> Plugins => new Dictionary<Guid, IPlugin> (_plugins);

    public IPlugin this [Guid id] => _plugins [id];

    public PluginManager (PluginManagerConfig config) {
        _config = config;

        LoadPlugins ();
    }

    private void LoadPlugins () {
        var files = Directory.GetFiles (_config.PluginsDirectory);

        foreach (var file in files) {
            LoadPlugin (file);
        }
    }

    public IPlugin LoadPlugin (string file) {
        var pluginLoader = new PluginLoader (_config.PluginLoadContextBuilder);

        if (Path.GetExtension (file) == ".dll") {
            var plugin = pluginLoader.LoadPlugin (file);

            if (_plugins.ContainsKey (plugin.Id)) {
                throw new DuplicatePluginIdException ($"Duplicate id {plugin.Id}");
            }

            _plugins.Add (plugin.Id, plugin);

            return plugin;
        }
        else {
            throw new ArgumentException ($"Provided file was not a dll: {file}");
        }
    }
}
