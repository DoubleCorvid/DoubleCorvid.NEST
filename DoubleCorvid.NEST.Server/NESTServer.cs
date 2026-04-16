using DoubleCorvid.NEST.Plugin;
using DoubleCorvid.NEST.Plugin.Manager;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
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

        _config.PluginManager.LoadPlugin (_config.HostPluginPath);

        var hostPlugin = _config.PluginManager.HostPlugin ?? throw new Exception ("Failed to load the host plugin.");

        hostPlugin.ConfigureAppBuilder (appBuilder);

        var services = appBuilder.Services.AddSingleton<IPluginManager> (_config.PluginManager);

        services.AddMvc ()
        .ConfigureApplicationPartManager (m => {
            m.FeatureProviders.Add (new PluginControllerFeatureProvider (_config.PluginManager));
        });

        hostPlugin.ConfigureServices (services);

        var serviceAdapter = new ServiceAdapter (services);

        var pluginManager = _config.PluginManager;

        foreach (var plugin in pluginManager.ServicePlugins.Values) {   
            plugin.RegisterSevices (serviceAdapter);
        }

        _app = appBuilder.Build ();

        _app.UseHttpsRedirection ();

        _app.MapControllers ();

        _initilized = true;
    }

    private void BuildMvcOptions (MvcOptions options) {
        throw new NotImplementedException ();
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
