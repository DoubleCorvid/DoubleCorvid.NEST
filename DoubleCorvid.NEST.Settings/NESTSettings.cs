using System.Text.Json.Serialization;

namespace DoubleCorvid.NEST.Settings;

public class NESTSettings : INESTSettings {
    [JsonIgnore]
    public string FullName { get; set; } = "";

    [JsonIgnore]
    public string PluginsDirectory { get; set; } = "";

    [JsonIgnore]
    public string ConfigDirectory { get; set; } = "";

    [JsonPropertyName ("port")]
    public int Port { get; init; }

    [JsonPropertyName ("address")]
    public string IPAddress { get; init; } = "127.0.0.1";
}
