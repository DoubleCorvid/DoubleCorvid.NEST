using System.Text.Json.Serialization;

using DoubleCorvid.NEST.FileManagement;

namespace DoubleCorvid.NEST.Settings;

public class NESTSettings : INESTSettings {
    [JsonIgnore]
    public string FullName { get; set; } = "";

    [JsonIgnore]
    public string PluginsDirectory { get; set; } = "";

    [JsonIgnore]
    public string ConfigDirectory { get; set; } = "";
}
