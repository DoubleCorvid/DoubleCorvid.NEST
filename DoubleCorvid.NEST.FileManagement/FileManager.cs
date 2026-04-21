namespace DoubleCorvid.NEST.FileManagement;

public class NESTFileManager (FileManagerConfig config) {
    private readonly FileManagerConfig _config = config;

    private readonly Dictionary<string, NESTFile> _files = [];

    public NESTFile LoadFile (string fullPath, bool getCachedIfAvailable = true) {
        var info = new FileInfo (fullPath);

        if (!info.Exists) {
           info.Create ().Close ();

           info.Refresh ();
        }

        if (getCachedIfAvailable && _files.TryGetValue (info.FullName, out var existing)) {
            return existing;
        }

        var file = new NESTFile (info, _config.Encoding);

        if (!_files.TryAdd (file.Info.FullName, file)) {
            throw new Exception ($"File already loaded: {file.Info.FullName}");
        }

        return file;
    }

    public bool UnloadFile (NESTFile file) => _files.Remove (file.Info.FullName);

    public NESTFile? GetFile (string fullName) {
        _files.TryGetValue (fullName, out var file);

        return file;
    }
}
