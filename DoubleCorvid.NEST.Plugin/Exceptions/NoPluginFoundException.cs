namespace DoubleCorvid.NEST.Plugin.Exceptions;

public class NoPluginFoundException : Exception {
    public NoPluginFoundException () { }

    public NoPluginFoundException (string? message) : base (message) { }

    public NoPluginFoundException (string? message, Exception? innerException) : base (message, innerException) { }
}
