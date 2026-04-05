using DoubleCorvid.NEST.Plugin.Load;

namespace DoubleCorvid.NEST.Plugin.Manager;

public class PluginManagerConfig {
    public required string PluginsDirectory { get; init; }

    public required IPluginLoadContextBuilder PluginLoadContextBuilder { get; init; }
}
