namespace DoubleCorvid.NEST.Server;

public interface INESTServer {
    void InitilizeApp ();

    void Run ();

    Task RunAsync ();

    Task StopAsync ();
}
