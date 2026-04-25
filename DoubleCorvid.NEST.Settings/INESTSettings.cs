using DoubleCorvid.Grimoire.Settings;

namespace DoubleCorvid.NEST.Settings;

public interface INESTSettings : ISettings {
    string PluginsDirectory { get; set; }

    string ConfigDirectory { get; set; }
}
