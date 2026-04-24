using DoubleCorvid.NEST.SettingsManagement;

namespace DoubleCorvid.NEST.Settings;

public class NESTSettingsManagerConfig : SettingsManagerConfig {
    public required string NESTSettingsFullPath { get; set; }
}