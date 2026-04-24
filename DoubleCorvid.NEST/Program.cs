using DoubleCorvid.NEST.FileManagement;
using DoubleCorvid.NEST.Plugin.Load;
using DoubleCorvid.NEST.Plugin.Manager;
using DoubleCorvid.NEST.Server;
using DoubleCorvid.NEST.Settings;

namespace DoubleCorvid.NEST;

public static class Program {
    private const string NESTSettingsFile = "nest.json";
    private const string HostPluginFile = "DoubleCorvid.NEST.Plugin.Sample.dll";
    private const string PluginsRelativeDirectory = "plugins/";
    private const string ConfigRelativeDirectory = "config/";

    private static string [] _args = [];

    private static string _cwd = "";

    private static string _nestSettingsPath = "";

    private static string _hostPluginPath = "";

    private static string _pluginsDirectory = "";

    private static string _configDirectory = "";

    private static IFileManager? _fileManager = null;

    private static NESTSettingsManager? _settingsManager = null;

    private static IPluginManager? _pluginManager = null;

    private static NESTServer? _nestServer = null;

    public static void Main (string [] args) {
        _args = args;

        SetupEnvironment ();

        _fileManager = BuildFileManager ();

        _settingsManager = BuildSettingsManager ();

        _settingsManager.NESTSettings.ConfigDirectory = _configDirectory;

        _settingsManager.NESTSettings.PluginsDirectory = _pluginsDirectory;

        _pluginManager = BuildPluginManager ();

        _nestServer = BuildNESTServer ();

        _nestServer.InitilizeApp ();
        
        _nestServer.Run ();
    }

    private static void SetupEnvironment () {
        _cwd = Directory.GetCurrentDirectory ();

        _nestSettingsPath = Path.Combine (_cwd, NESTSettingsFile);

        // if (!File.Exists (_nestSettingsPath)) {
        //     var json = JsonSerializer.Serialize (new NESTSettings ()) ?? throw new Exception ("Failed to serialize a default instance of NEST settings");

        //     File.WriteAllText (_nestSettingsPath, json);
        // }

        _hostPluginPath = Path.Combine (_cwd, HostPluginFile);

        if (!File.Exists (_hostPluginPath)) {
            throw new Exception ($"A host plugin was not found at {_hostPluginPath}.");
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

    private static FileManager BuildFileManager () => new (BuildFileManagerConfig ());

    private static FileManagerConfig BuildFileManagerConfig () {
        return new () {
            Encoding = System.Text.Encoding.UTF8
        };
    }

    private static NESTSettingsManager BuildSettingsManager () => new (BuildSettingsManagerConfig ());

    private static NESTSettingsManagerConfig BuildSettingsManagerConfig () {
        return new NESTSettingsManagerConfig {
            FileManager = _fileManager ?? throw new Exception ("Settings manager wasn't initilized before attempting to use it."),
            NESTSettingsFullPath = _nestSettingsPath
        };
    }

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
        HostPluginPath = _hostPluginPath,
    };
}
