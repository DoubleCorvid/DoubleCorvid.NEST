namespace DoubleCorvid.NEST.Plugin;

public interface IServicePlugin : IPlugin {
    void RegisterSevices (IServiceAdapter serviceAdapter);
}
