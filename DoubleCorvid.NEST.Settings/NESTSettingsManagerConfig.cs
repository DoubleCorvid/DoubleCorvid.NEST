using DoubleCorvid.Grimoire.Settings;

namespace DoubleCorvid.NEST.Settings;

public class NESTSettingsManagerConfig : SettingsManagerConfig, INESTSettingsManagerConfig {
    public required string NESTSettingsFullPath { get; set; }
}
