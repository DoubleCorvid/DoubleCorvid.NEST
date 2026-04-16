using System.Reflection;
using DoubleCorvid.NEST.Plugin.Manager;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;

namespace DoubleCorvid.NEST.Plugin;

public class PluginControllerFeatureProvider (IPluginManager pluginManager) : IApplicationFeatureProvider<ControllerFeature> {
    private readonly IPluginManager _pluginManager = pluginManager;

    public void PopulateFeature (IEnumerable<ApplicationPart> parts, ControllerFeature feature) {
        foreach (var plugin in _pluginManager.Plugins.Values) {
            if (plugin is not IControllerPlugin controllerPlugin) {
                continue;
            }

            foreach (var controller in controllerPlugin.ControllerTypes) {
                feature.Controllers.Add (controller.GetTypeInfo ());
            }
        }
    }
}
