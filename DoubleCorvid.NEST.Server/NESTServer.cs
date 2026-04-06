using DoubleCorvid.NEST.Plugin.Manager;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DoubleCorvid.NEST.Server;

public class NESTServer (INESTServerConfig config) : INESTServer{
    private readonly INESTServerConfig _config = config;

    private WebApplication? _app;

    private bool _initilized = false;

    private bool _running = false;

    public void InitilizeApp () {
        if (_running) {
            throw new Exception ("Tried to initilize the app while it's running.");
        }

        var appBuilder = WebApplication.CreateBuilder (_config.Args);

        var plugins = _config.PluginManager.Plugins.Values;

        foreach (var plugin in plugins) {
            plugin.ConfigureAppBuilder (appBuilder);
        }

        var services = appBuilder.Services;

        services.AddSingleton<IPluginManager> (_config.PluginManager);

        foreach (var plugin in plugins) {
            plugin.ConfigureServices (services);
        }

        _app = appBuilder.Build ();

        foreach (var plugin in plugins) {
            plugin.ConfigureApp (_app);
        }

        _initilized = true;
    }

    public void Run () {
        if (!_initilized || _app is null) {
            throw new Exception ("The web app must be initilized before it can be ran.");
        }

        _running = true;

        _app.Run ();
    }

    public async Task RunAsync () {
        if (!_initilized || _app is null) {
            throw new Exception ("The web app must be initilized before it can be ran.");
        }

        _running = true;

        await _app.RunAsync ();
    }

    public async Task StopAsync () {
        if (!_running || _app is null) {
            throw new Exception ("You must first initilize and start the web app to stop it.");
        }

        await _app.StopAsync ();

        _running = false;
    }
}
