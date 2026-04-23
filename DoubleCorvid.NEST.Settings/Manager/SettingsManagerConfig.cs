using DoubleCorvid.NEST.FileManagement;

namespace DoubleCorvid.NEST.Settings.Manager;

public class SettingsManagerConfig {
    public required IFileManager FileManager { get; init; }
}
