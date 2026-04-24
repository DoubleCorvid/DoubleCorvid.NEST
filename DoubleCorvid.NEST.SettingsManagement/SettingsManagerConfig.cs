using DoubleCorvid.NEST.FileManagement;

namespace DoubleCorvid.NEST.SettingsManagement;

public class SettingsManagerConfig {
    public required IFileManager FileManager { get; init; }
}
