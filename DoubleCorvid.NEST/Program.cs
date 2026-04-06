using System.Text.Json;
using DoubleCorvid.NEST.Plugin.Load;
using DoubleCorvid.NEST.Plugin.Manager;
using DoubleCorvid.NEST.Server;
using DoubleCorvid.NEST.Settings;
using DoubleCorvid.NEST.Settings.Manager;

namespace DoubleCorvid.NEST;

public static class Program {
    private const string NESTSettingsFile = "nest.json";
    private const string PluginsRelativeDirectory = "plugins/";
    private const string ConfigRelativeDirectory = "config/";

    private static string [] _args = [];

    private static string _cwd = "";

    private static string _nestSettingsPath = "";

    private static string _pluginsDirectory = "";

    private static string _configDirectory = "";

    private static SettingsManager? _settingsManager = null;

    private static PluginManager? _pluginManager = null;

    private static NESTServer? _nestServer = null;

    public static void Main (string [] args) {
        _args = args;

        SetupEnvironment ();

        _settingsManager = BuildSettingsManager ();

        _settingsManager.NESTSettings.ConfigDirectory = _configDirectory;

        _settingsManager.NESTSettings.PluginsDirectory = _pluginsDirectory;

        _pluginManager = BuildPluginManager ();

        _pluginManager.LoadPlugins ();

        _nestServer = BuildNESTServer ();

        _nestServer.InitilizeApp ();
        
        _nestServer.Run ();
    }

    private static void SetupEnvironment () {
        _cwd = Directory.GetCurrentDirectory ();

        _nestSettingsPath = Path.Combine (_cwd, NESTSettingsFile);

        if (!File.Exists (_nestSettingsPath)) {
            var json = JsonSerializer.Serialize (new NESTSettings ()) ?? throw new Exception ("Failed to serialize a default instance of NEST settings");

            File.WriteAllText (_nestSettingsPath, json);
        }

        _pluginsDirectory = Path.Combine (_cwd, PluginsRelativeDirectory);

        if (!Directory.Exists (_pluginsDirectory)) {
            Directory.CreateDirectory (_pluginsDirectory);
        }

        _configDirectory = Path.Combine (_cwd, ConfigRelativeDirectory);
        
        if (!Directory.Exists (_configDirectory)) {
            Directory.CreateDirectory (_configDirectory);
        }
    }

    private static SettingsManager BuildSettingsManager () => new (_nestSettingsPath);

    private static PluginManager BuildPluginManager () => new (BuildPluginManagerConfig ());

    private static PluginManagerConfig BuildPluginManagerConfig () => new () {
        PluginLoadContextBuilder = new PluginLoadContextBuilder (),
        SettingsManager = _settingsManager ?? throw new Exception ("Settings manager wasn't initilized before attempting to use it."),
    };

    private static NESTServer BuildNESTServer () => new (BuildNESTServerConfig ());

    private static NESTServerConfig BuildNESTServerConfig () => new () {
        Args = _args,
        SettingsManager = _settingsManager ?? throw new Exception ("Settings manager wasn't initilized before attempting to use it."),
        PluginManager = _pluginManager ?? throw new Exception ("Plugin manager wasn't initilized before attempting to use it."),
    };
}


