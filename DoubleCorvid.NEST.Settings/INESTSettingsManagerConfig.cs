using DoubleCorvid.Grimoire.Settings;

namespace DoubleCorvid.NEST.Settings;

public interface INESTSettingsManagerConfig : ISettingsManagerConfig {
    string NESTSettingsFullPath { get; }
}