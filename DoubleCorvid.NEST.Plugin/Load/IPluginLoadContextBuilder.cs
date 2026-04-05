namespace DoubleCorvid.NEST.Plugin.Load;

public interface IPluginLoadContextBuilder {
    PluginLoadContextBuilder WithPluginPath (string pluginPath);

    PluginLoadContext Build ();
}
