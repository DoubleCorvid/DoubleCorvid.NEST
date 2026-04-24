namespace DoubleCorvid.NEST.FileManagement;

public interface IFileManager {
    IReadOnlyDictionary<string, ManagedFile> Files { get; }

    ManagedFile? TryGetFile (string fullName);

    ManagedFile LoadFile (string fullPath, bool preferCached = true);
    
    bool UnloadFile (string fullName);
}
