using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DoubleCorvid.NEST.Plugin;

public interface IHostPlugin : IPlugin {
    void ConfigureAppBuilder (WebApplicationBuilder appBuilder);

    void ConfigureServices (IServiceCollection services);

    void ConfigureApp (WebApplication app);
}
