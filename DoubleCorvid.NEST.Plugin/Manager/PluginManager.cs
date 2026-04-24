using DoubleCorvid.NEST.Plugin.Exceptions;
using DoubleCorvid.NEST.Plugin.Load;

namespace DoubleCorvid.NEST.Plugin.Manager;

public class PluginManager : IPluginManager {
    private readonly IPluginManagerConfig _config;

    private readonly Dictionary<Guid, IPlugin> _plugins = [];

    public IReadOnlyDictionary<Guid, IPlugin> Plugins => new Dictionary<Guid, IPlugin> (_plugins);

    public IHostPlugin? HostPlugin { get; private set; }

    private readonly Dictionary<Guid, IServicePlugin> _servicePlugins = [];

    public IReadOnlyDictionary<Guid, IServicePlugin> ServicePlugins => new Dictionary<Guid, IServicePlugin> (_servicePlugins);

    private readonly Dictionary<Guid, IControllerPlugin> _controllerPlugins = [];

    public PluginManager (IPluginManagerConfig config) {
        _config = config;

        var pluginDir = _config.SettingsManager.NESTSettings.PluginsDirectory;

        if (!Directory.Exists (pluginDir)) {
            Directory.CreateDirectory (pluginDir);
        }

        LoadPlugins (pluginDir);
    }

    public IReadOnlyDictionary<Guid, IControllerPlugin> ControllerPlugins => new Dictionary<Guid, IControllerPlugin> (_controllerPlugins);

    public IPlugin this [Guid id] => _plugins [id];

    private void LoadPlugins (string pluginsDirectory) {
        var files = Directory.GetFiles (pluginsDirectory).Where (f => Path.GetExtension (f) == ".dll");

        foreach (var file in files) {
            LoadPlugin (file);
        }
    }

    public IPlugin LoadPlugin (string file) {
        var pluginLoader = new PluginLoader (_config.PluginLoadContextBuilder);

        if (Path.GetExtension (file) != ".dll") {
            throw new ArgumentException ($"Provided file was not a dll: {file}");
        }
        
        var plugin = pluginLoader.LoadPlugin (file);

        if (_plugins.ContainsKey (plugin.Id)) {
            throw new DuplicatePluginIdException ($"Tried to add plugin with duplicate id {plugin.Id}.");
        }

        if (plugin.GetType ().IsAssignableTo (typeof (IHostPlugin))) {
            if (HostPlugin is not null) {
                throw new Exception ("Please provide only one host plugin.");
            }

            HostPlugin = (IHostPlugin) plugin;
        }

        _plugins.Add (plugin.Id, plugin);

        if (plugin.GetType ().IsAssignableTo (typeof (IServicePlugin))) {
            _servicePlugins.Add (plugin.Id, (IServicePlugin) plugin);
        }
        
        if (plugin.GetType ().IsAssignableTo (typeof (IControllerPlugin))) {
            _controllerPlugins.Add (plugin.Id, (IControllerPlugin) plugin);
        }

        return plugin;
    }
}
