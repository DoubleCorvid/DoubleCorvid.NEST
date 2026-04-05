namespace DoubleCorvid.NEST.Plugin.Load;

public class PluginLoadContextBuilder : IPluginLoadContextBuilder {
    private string _pluginPath = "";

    public PluginLoadContextBuilder WithPluginPath (string pluginPath) {
        _pluginPath = pluginPath;

        return this;
    }

    public PluginLoadContext Build () => new (_pluginPath);
}
