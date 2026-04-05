namespace DoubleCorvid.NEST.Plugin.Exceptions;

public class FailedToCreatePluginInstanceException : Exception {
    public FailedToCreatePluginInstanceException () { }

    public FailedToCreatePluginInstanceException (string? message) : base (message) { }

    public FailedToCreatePluginInstanceException (string? message, Exception? innerException) : base (message, innerException) { }
}
