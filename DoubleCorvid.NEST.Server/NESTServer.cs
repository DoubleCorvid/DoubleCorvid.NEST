using System.Net;

using DoubleCorvid.Grimoire.Files;
using DoubleCorvid.NEST.Plugin;
using DoubleCorvid.NEST.Plugin.Manager;
using DoubleCorvid.NEST.Settings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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

        appBuilder.WebHost.ConfigureKestrel (k => {
            k.Listen (IPAddress.Parse (_config.SettingsManager.NESTSettings.IPAddress), _config.SettingsManager.NESTSettings.Port);
        });

        var pluginManager = _config.PluginManager;

        pluginManager.LoadPlugin (_config.HostPluginPath);

        pluginManager.LoadPluginsDirectory ();

        var hostPlugin = pluginManager.HostPlugin ?? throw new Exception ("Failed to load the host plugin.");

        hostPlugin.ConfigureAppBuilder (appBuilder);

        var services = appBuilder.Services.AddSingleton<IPluginManager> (pluginManager);

        services.AddMvc ()
        .ConfigureApplicationPartManager (m => {
            m.FeatureProviders.Add (new PluginControllerFeatureProvider (pluginManager));
        });

        services.AddSingleton<IFileManager> (_config.FileManager);

        services.AddSingleton<INESTSettingsManager> (_config.SettingsManager);

        hostPlugin.ConfigureServices (services);

        var serviceAdapter = new ServiceAdapter (services);

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
