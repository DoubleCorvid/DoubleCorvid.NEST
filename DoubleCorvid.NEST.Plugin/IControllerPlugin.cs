namespace DoubleCorvid.NEST.Plugin;

public interface IControllerPlugin : IPlugin {
    IEnumerable<Type> ControllerTypes { get; } 
}
