namespace DoubleCorvid.NEST.Settings.Manager;

public interface ISettingsManager {
    INESTSettings NESTSettings { get; }
    
    ISettings? TryGet (string name);

    ISettings LoadSettingsFile<T> (string file) where T : ISettings;
}
