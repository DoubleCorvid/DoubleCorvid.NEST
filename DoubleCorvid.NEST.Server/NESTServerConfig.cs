using DoubleCorvid.NEST.Plugin.Manager;

namespace DoubleCorvid.NEST.Server;

public class NESTServerConfig {
    public required string[] Args { get; init; }

    public required IPluginManager PluginManager { get; init; }
}