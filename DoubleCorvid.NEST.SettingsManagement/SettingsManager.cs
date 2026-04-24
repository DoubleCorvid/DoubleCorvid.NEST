using System.Text.Json;

namespace DoubleCorvid.NEST.SettingsManagement;

public class SettingsManager (SettingsManagerConfig config) : ISettingsManager {
    private readonly SettingsManagerConfig _config = config;

    private readonly Dictionary<string, ISettings> _settings = [];

    public ISettings? TryGet (string fullName) {
        if (_settings.TryGetValue (fullName, out var found)) {
            return found;
        }

        return null;
    }

    public ISettings LoadSettingsFile<T> (string fullPath, bool preferCached = true) where T : ISettings {
        ArgumentNullException.ThrowIfNullOrWhiteSpace (fullPath);

        var file = _config.FileManager.LoadFile (fullPath);

        string fullName = file.FullName;

        if (preferCached && _settings.TryGetValue (fullName, out var cached)) {
            return cached;
        }

        var contents = file.Read ();

        var settings = JsonSerializer.Deserialize<T> (contents) ?? throw new Exception ($"Failed to Deserialize settings from file {fullName}.");

        if (string.IsNullOrEmpty (settings.FullName)) {
            settings.FullName = fullName;
        }

        _settings [settings.FullName] = settings;

        return settings;
    }

    public bool UnloadSettings (string fullName) {
        _config.FileManager.UnloadFile (fullName);

        return _settings.Remove (fullName);
    }
}
