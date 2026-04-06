using DoubleCorvid.NEST.Plugin.Load;
using DoubleCorvid.NEST.Settings.Manager;

namespace DoubleCorvid.NEST.Plugin.Manager;

public interface IPluginManagerConfig {
    ISettingsManager SettingsManager { get; }
    
    IPluginLoadContextBuilder PluginLoadContextBuilder { get; }
}
