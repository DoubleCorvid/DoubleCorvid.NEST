namespace DoubleCorvid.NEST.Plugin.Manager;

public interface IPluginManager {
    IReadOnlyDictionary<Guid, IPlugin> Plugins { get; }
    
    IHostPlugin? HostPlugin { get; }

    IReadOnlyDictionary<Guid, IControllerPlugin> ControllerPlugins { get; }
    
    IReadOnlyDictionary<Guid, IServicePlugin> ServicePlugins { get; }

    IPlugin? this [Guid id] { get; }

    void LoadPluginsDirectory ();

    IPlugin LoadPlugin (string file);
}
