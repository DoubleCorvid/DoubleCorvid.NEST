namespace DoubleCorvid.NEST.SettingsManagement;

public interface ISettingsManager {
    IReadOnlyDictionary<string, ISettings> Settings { get; }

    ISettings? TryGet (string fullName);

    ISettings LoadSettingsFile<T> (string fullName, bool preferCached = true) where T : ISettings;

    bool UnloadSettings (string fullPath);
}
