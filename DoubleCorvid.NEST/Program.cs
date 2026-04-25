using DoubleCorvid.Grimoire.Files;
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

    private static INESTSettingsManager? _settingsManager = null;

    private static IPluginManager? _pluginManager = null;

    private static NESTServer? _nestServer = null;

    public static void Main (string [] args) {
        _args = args;

        _cwd = Directory.GetCurrentDirectory ();

        _nestSettingsPath = Path.Combine (_cwd, NESTSettingsFile);

        _hostPluginPath = Path.Combine (_cwd, HostPluginFile);

        _pluginsDirectory = Path.Combine (_cwd, PluginsRelativeDirectory);

        _configDirectory = Path.Combine (_cwd, ConfigRelativeDirectory);

        _fileManager = BuildFileManager ();

        _settingsManager = BuildSettingsManager ();

        _pluginManager = BuildPluginManager ();

        _nestServer = BuildNESTServer ();
        
        _nestServer.Run ();
    }

    private static FileManager BuildFileManager () => new (BuildFileManagerConfig ());

    private static FileManagerConfig BuildFileManagerConfig () => new () {
        Encoding = System.Text.Encoding.UTF8
    };

    private static NESTSettingsManager BuildSettingsManager () {
        var manager = new NESTSettingsManager (BuildSettingsManagerConfig ());

        manager.NESTSettings.ConfigDirectory = _configDirectory;

        manager.NESTSettings.PluginsDirectory = _pluginsDirectory;

        return manager;
    }

    private static NESTSettingsManagerConfig BuildSettingsManagerConfig () => new () {
        FileManager = _fileManager ?? throw new Exception ("File manager wasn't initilized before attempting to use it."),
        NESTSettingsFullPath = _nestSettingsPath
    };

    private static PluginManager BuildPluginManager () => new (BuildPluginManagerConfig ());

    private static PluginManagerConfig BuildPluginManagerConfig () => new () {
        PluginLoadContextBuilder = new PluginLoadContextBuilder (),
        SettingsManager = _settingsManager ?? throw new Exception ("Settings manager wasn't initilized before attempting to use it."),
    };

    private static NESTServer BuildNESTServer () { 
        var server = new NESTServer (BuildNESTServerConfig ());

        server.InitilizeApp ();

        return server;
    }

    private static NESTServerConfig BuildNESTServerConfig () => new () {
        Args = _args,
        FileManager = _fileManager ?? throw new Exception ("File manager wasn't initilized before attempting to use it."),
        SettingsManager = _settingsManager ?? throw new Exception ("Settings manager wasn't initilized before attempting to use it."),
        PluginManager = _pluginManager ?? throw new Exception ("Plugin manager wasn't initilized before attempting to use it."),
        HostPluginPath = _hostPluginPath,
    };
}
