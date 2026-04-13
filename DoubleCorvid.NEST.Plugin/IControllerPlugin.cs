using Microsoft.Extensions.DependencyInjection;

namespace DoubleCorvid.NEST.Plugin;

public interface IControllerPlugin : IPlugin {
    void RegisterControllers (IMvcBuilder mvcBuilder);
}
