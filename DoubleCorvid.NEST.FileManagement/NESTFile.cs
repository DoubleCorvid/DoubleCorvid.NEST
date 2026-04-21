using System.Text;

namespace DoubleCorvid.NEST.FileManagement;

public class NESTFile (FileInfo info, Encoding encoding) {
    public FileInfo Info { get; } = info;

    private readonly Encoding _encoding = encoding;

    public void Create (bool recreate = false) {
        if (Info.Exists) {
            if (recreate) {
                Info.Delete ();
            }
            else {
                return;
            }
        }

        Info.Create ().Close () ;
    }

    public string Read () {
        BeginOperation ();

        using var fs = Info.OpenRead ();

        using var reader = new StreamReader (fs, _encoding);

        var content = reader.ReadToEnd ();

        return content;
    }

    public void Overwrite (string content) {
        BeginOperation ();
        
        using var fs = Info.OpenWrite ();

        using var writer = new StreamWriter (fs, _encoding);

        Create (true);

        writer.Write (content);
    }

    public void Append (string content) {
        BeginOperation ();

        StreamWriter? writer = null;

        try {
            writer = Info.AppendText ();

            writer.Write (content);
        }
        finally {
            writer?.Close ();
        }
    }

    public void Delete () {
        BeginOperation ();

        Info.Delete ();
    }

    private void BeginOperation () {
        Info.Refresh ();

        ThrowIfFileNotFound ();
    }

    private void ThrowIfFileNotFound () {
        if (!Info.Exists) {
            throw new FileNotFoundException ($"Tried to opperate on a file but it was not found: {Info.FullName}");
        }
    }
}
