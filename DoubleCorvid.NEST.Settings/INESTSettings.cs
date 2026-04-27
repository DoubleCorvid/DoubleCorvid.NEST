using DoubleCorvid.Grimoire.Settings;

namespace DoubleCorvid.NEST.Settings;

public interface INESTSettings : ISettings {
    string PluginsDirectory { get; }

    string ConfigDirectory { get; }

    int Port { get; }
}
