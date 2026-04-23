using DoubleCorvid.NEST.FileManagement;

namespace DoubleCorvid.NEST.Settings;

public interface ISettings {
    ManagedFile File { get; set; }
}
