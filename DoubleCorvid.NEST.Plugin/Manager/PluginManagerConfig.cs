using DoubleCorvid.NEST.Plugin.Load;
using DoubleCorvid.NEST.Settings;

namespace DoubleCorvid.NEST.Plugin.Manager;

public class PluginManagerConfig : IPluginManagerConfig {
    public required IPluginLoadContextBuilder PluginLoadContextBuilder { get; init; }
    
    public required INESTSettingsManager SettingsManager { get; init; }
}
