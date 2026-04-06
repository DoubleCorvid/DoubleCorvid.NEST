using System.Text.Json;


namespace DoubleCorvid.NEST.Settings.Manager;

public class SettingsManager : ISettingsManager {
    public INESTSettings NESTSettings { get; }

    private readonly Dictionary<string, ISettings> _settings = [];

    public SettingsManager (string path) {
        NESTSettings = (INESTSettings) LoadSettingsFile<NESTSettings> (path);
    }

    public ISettings? TryGet (string name) {
        if (_settings.TryGetValue (name, out var found)) {
            return found;
        }

        return null;
    }

    public ISettings LoadSettingsFile<T> (string file) where T : ISettings {
        if (string.IsNullOrWhiteSpace (file)) {
            throw new Exception ("The provided path was null or whitespace");
        }

        if (!File.Exists (file)) {
            throw new Exception ("Provided file path doesn't exist");
        }

        var name = Path.GetFileNameWithoutExtension (file);

        if (_settings.ContainsKey (name)) {
            throw new Exception ($"Already loaded settings from file {file}.");
        }

        var contents = File.ReadAllText (file);

        var settings = JsonSerializer.Deserialize<T> (contents) ?? throw new Exception ($"Failed to Deserialize settings from file {file}.");

        _settings.Add (name, settings);

        return settings;
    }
}
