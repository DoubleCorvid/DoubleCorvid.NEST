namespace DoubleCorvid.NEST.FileManagement;

public class FileManager (FileManagerConfig config) : IFileManager {
    private readonly FileManagerConfig _config = config;

    private readonly Dictionary<string, ManagedFile> _files = [];

    public ManagedFile LoadFile (string fullPath, bool preferCached = true) {
        ArgumentNullException.ThrowIfNullOrWhiteSpace (fullPath);

        var info = new FileInfo (fullPath);

        if (!info.Exists) {
           info.Create ().Close ();

           info.Refresh ();
        }

        if (preferCached && _files.TryGetValue (info.FullName, out var existing)) {
            return existing;
        }

        var file = new ManagedFile (info, _config.Encoding);

        if (!_files.TryAdd (file.FullName, file)) {
            throw new Exception ($"File already loaded: {file.FullName}");
        }

        return file;
    }

    public bool UnloadFile (ManagedFile file) => _files.Remove (file.FullName);


    public ManagedFile? TryGetFile (string fullName) {
        _files.TryGetValue (fullName, out var file);

        return file;
    }
}
