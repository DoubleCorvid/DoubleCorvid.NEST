using DoubleCorvid.NEST.Plugin.Load;
using DoubleCorvid.NEST.SettingsManagement;

namespace DoubleCorvid.NEST.Plugin.Manager;

public class PluginManagerConfig : IPluginManagerConfig {
    public required IPluginLoadContextBuilder PluginLoadContextBuilder { get; init; }
    
    public required ISettingsManager SettingsManager { get; init; }
}
