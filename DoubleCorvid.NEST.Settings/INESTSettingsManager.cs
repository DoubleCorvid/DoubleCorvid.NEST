using DoubleCorvid.NEST.SettingsManagement;

namespace DoubleCorvid.NEST.Settings;

public interface INESTSettingsManager : ISettingsManager {
    NESTSettings NESTSettings { get; }
}
