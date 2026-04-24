using DoubleCorvid.NEST.Plugin.Load;
using DoubleCorvid.NEST.Settings;

namespace DoubleCorvid.NEST.Plugin.Manager;

public interface IPluginManagerConfig {
    INESTSettingsManager SettingsManager { get; }
    
    IPluginLoadContextBuilder PluginLoadContextBuilder { get; }
}
