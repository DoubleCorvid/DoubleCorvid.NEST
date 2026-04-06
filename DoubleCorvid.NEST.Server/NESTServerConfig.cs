using DoubleCorvid.NEST.Plugin.Manager;
using DoubleCorvid.NEST.Settings.Manager;

namespace DoubleCorvid.NEST.Server;

public class NESTServerConfig : INESTServerConfig{
    public required string[] Args { get; init; }

    public required ISettingsManager SettingsManager { get; init; }

    public required IPluginManager PluginManager { get; init; }
}
