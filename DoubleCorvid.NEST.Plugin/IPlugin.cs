using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DoubleCorvid.NEST.Plugin;

public interface IPlugin {
    Guid Id { get; }
    
    string LongName { get; }

    string ShortName { get; }

    string Version { get; }

    string ShortDescription { get; }

    string LongDescription { get; }

    string [] URLs { get; }

    string [] Authors { get; }

    string License { get; }

    string Copyright { get; }

    WebApplicationBuilder ConfigureAppBuilder (WebApplicationBuilder appBuilder);

    IMvcCoreBuilder ConfigureControllers (IMvcCoreBuilder builder);

    IServiceCollection ConfigureServices (IServiceCollection services);

    WebApplication ConfigureApp (WebApplication app);
}
