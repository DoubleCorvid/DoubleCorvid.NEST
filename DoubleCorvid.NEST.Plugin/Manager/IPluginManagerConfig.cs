using DoubleCorvid.NEST.Plugin.Load;
using DoubleCorvid.NEST.SettingsManagement;

namespace DoubleCorvid.NEST.Plugin.Manager;

public interface IPluginManagerConfig {
    ISettingsManager SettingsManager { get; }
    
    IPluginLoadContextBuilder PluginLoadContextBuilder { get; }
}
