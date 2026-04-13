using Microsoft.AspNetCore.Mvc;

namespace DoubleCorvid.NEST.Plugin.Sample;

public class WeatherForecastController : ControllerBase {
    private readonly WeeklyForecast _weekly = new ();

    [HttpGet ("")]
    public WeeklyForecast Weekly () => _weekly;
}
