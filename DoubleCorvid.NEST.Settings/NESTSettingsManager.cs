using DoubleCorvid.NEST.SettingsManagement;

namespace DoubleCorvid.NEST.Settings;

public class NESTSettingsManager : SettingsManager, INESTSettingsManager {
    public NESTSettings NESTSettings { get; }

    public NESTSettingsManager (NESTSettingsManagerConfig config) : base (config) {
        NESTSettings = (NESTSettings) LoadSettingsFile<NESTSettings> (config.NESTSettingsFullPath);
    }
}
