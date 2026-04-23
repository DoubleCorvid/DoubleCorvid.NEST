using DoubleCorvid.NEST.FileManagement;

namespace DoubleCorvid.NEST.Settings.Manager;

public interface ISettingsManager {
    ISettings? TryGet (string fullName);

    ISettings LoadSettingsFile<T> (string file, bool preferCached = true) where T : ISettings;

    bool UnloadSettings (ISettings file);
}
