using DoubleCorvid.NEST.Plugin.Manager;
using DoubleCorvid.NEST.Settings;

namespace DoubleCorvid.NEST.Server;

public interface INESTServerConfig {
    string[] Args { get; }

    INESTSettingsManager SettingsManager { get; }

    IPluginManager PluginManager { get; }

    string HostPluginPath { get; }
}