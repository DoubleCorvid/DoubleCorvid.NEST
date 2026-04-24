using DoubleCorvid.NEST.Plugin.Manager;
using DoubleCorvid.NEST.Settings;

namespace DoubleCorvid.NEST.Server;

public class NESTServerConfig : INESTServerConfig {
    public required string[] Args { get; init; }

    public required INESTSettingsManager SettingsManager { get; init; }

    public required IPluginManager PluginManager { get; init; }

    public required string HostPluginPath { get; init; }
}
