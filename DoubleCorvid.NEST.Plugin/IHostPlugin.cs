using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DoubleCorvid.NEST.Plugin;

public interface IHostPlugin : IPlugin {
    WebApplicationBuilder ConfigureAppBuilder (WebApplicationBuilder appBuilder);

    IServiceCollection ConfigureServices (IServiceCollection services);

    WebApplication ConfigureApp (WebApplication app);
}
