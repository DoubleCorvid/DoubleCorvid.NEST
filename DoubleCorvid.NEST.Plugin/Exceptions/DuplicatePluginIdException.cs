namespace DoubleCorvid.NEST.Plugin.Exceptions;

public class DuplicatePluginIdException : Exception {
    public DuplicatePluginIdException () { }

    public DuplicatePluginIdException (string? message) : base (message) { }

    public DuplicatePluginIdException (string? message, Exception? innerException) : base (message, innerException) { }
}
