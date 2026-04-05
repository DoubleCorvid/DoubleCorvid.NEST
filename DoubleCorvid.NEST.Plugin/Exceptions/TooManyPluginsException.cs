namespace DoubleCorvid.NEST.Plugin.Exceptions;

public class TooManyPluginsException : Exception {
    public TooManyPluginsException () { }

    public TooManyPluginsException (string? message) : base (message) { }

    public TooManyPluginsException (string? message, Exception? innerException) : base (message, innerException) { }
}
