namespace DoubleCorvid.NEST.Plugin.Manager;

public interface IPluginManager {
    IHostPlugin? HostPlugin { get; }

    IReadOnlyDictionary<Guid, IControllerPlugin> ControllerPlugins { get; }
    
    IReadOnlyDictionary<Guid, IServicePlugin> ServicePlugins { get; }

    IPlugin this [Guid id] { get; }

    IPlugin LoadPlugin (string file);
}
