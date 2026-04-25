using DoubleCorvid.Grimoire.Files;
using DoubleCorvid.NEST.Plugin.Manager;
using DoubleCorvid.NEST.Settings;

namespace DoubleCorvid.NEST.Server;

public interface INESTServerConfig {
    string[] Args { get; }

    IFileManager FileManager { get; }

    INESTSettingsManager SettingsManager { get; }

    IPluginManager PluginManager { get; }

    string HostPluginPath { get; }
}