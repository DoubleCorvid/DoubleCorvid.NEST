using DoubleCorvid.NEST.Plugin.Manager;
using DoubleCorvid.NEST.Settings.Manager;

namespace DoubleCorvid.NEST.Server;

public interface INESTServerConfig {
    string[] Args { get; }

    ISettingsManager SettingsManager { get; }

    IPluginManager PluginManager { get; }

    string HostPluginPath { get; }
}