using DoubleCorvid.NEST.FileManagement;

namespace DoubleCorvid.NEST.SettingsManagement;

public interface ISettings {
    ManagedFile File { get; set; }
}
