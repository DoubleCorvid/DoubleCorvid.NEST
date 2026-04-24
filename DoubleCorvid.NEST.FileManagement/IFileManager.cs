namespace DoubleCorvid.NEST.FileManagement;

public interface IFileManager {
    ManagedFile LoadFile (string fullPath, bool preferCached = true);
    
    bool UnloadFile (string fullName);

    ManagedFile? TryGetFile (string fullName);
}
