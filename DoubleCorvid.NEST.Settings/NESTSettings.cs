using System.Text.Json.Serialization;

namespace DoubleCorvid.NEST.Settings;

public class NESTSettings : INESTSettings {
    [JsonIgnore]
    public string PluginsDirectory { get; set; } = "";

    [JsonIgnore]
    public string ConfigDirectory { get; set; } = "";
}