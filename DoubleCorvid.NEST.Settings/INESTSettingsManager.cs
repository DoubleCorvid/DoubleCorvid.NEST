using DoubleCorvid.Grimoire.Settings;

namespace DoubleCorvid.NEST.Settings;

public interface INESTSettingsManager : ISettingsManager {
    NESTSettings NESTSettings { get; }
}
