namespace DoubleCorvid.NEST.Plugin.Manager;

public interface IPluginManager {
    IReadOnlyDictionary<Guid, IPlugin> Plugins { get; }

    IPlugin this [Guid id] { get; }

    IPlugin LoadPlugin (string file);
}
