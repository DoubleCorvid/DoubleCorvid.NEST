using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DoubleCorvid.NEST.Plugin.Sample;

public class WeatherForecastPlugin : IHostPlugin, IServicePlugin, IControllerPlugin, IPlugin {
    public Guid Id => new ();

    public string LongName => "NEST Plugin Weather Forecast Plugin";

    public string ShortName => "Sample Plugin";

    public string Version => "1.0.0";

    public string ShortDescription => "A sample weather forecast plugin.";

    public string LongDescription => "A sample weather forecast plugin.";

    public string[ ] URLs => [];

    public string[ ] Authors => [ "DoubleCorvid" ];

    public string License => "MIT";

    public string Copyright => "Copyright © DoubleCorvid";

    private IMvcBuilder? _mvcBuilder = null;
    
    public void RegisterSevices (IServiceAdapter serviceAdapter) {
        
    }

    public WebApplicationBuilder ConfigureAppBuilder (WebApplicationBuilder appBuilder) {
        return appBuilder;
    }

    public IServiceCollection ConfigureServices (IServiceCollection services) {
        _mvcBuilder = services.AddMvc ();

        return services;
    }

    public WebApplication ConfigureApp (WebApplication app) {
        return app;
    }

    public IMvcBuilder GetMvcBuilder () => _mvcBuilder ?? throw new Exception ("Services must be configured first before the MVC builder is populated");

    public void RegisterControllers (IMvcBuilder mvcBuilder) {
        mvcBuilder.AddControllersAsServices ().AddApplicationPart (this.GetType ().Assembly);
    }
}
