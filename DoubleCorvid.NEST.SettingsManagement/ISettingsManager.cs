namespace DoubleCorvid.NEST.SettingsManagement;

public interface ISettingsManager {
    ISettings? TryGet (string fullName);

    ISettings LoadSettingsFile<T> (string fullName, bool preferCached = true) where T : ISettings;

    bool UnloadSettings (string fullPath);
}
