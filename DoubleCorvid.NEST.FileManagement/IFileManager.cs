namespace DoubleCorvid.NEST.FileManagement;

public interface IFileManager {
    ManagedFile LoadFile (string fullPath, bool preferCached = true);
    
    bool UnloadFile (ManagedFile file);

    ManagedFile? TryGetFile (string fullName);
}
