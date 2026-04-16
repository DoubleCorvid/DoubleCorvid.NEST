using Microsoft.AspNetCore.Mvc;

namespace DoubleCorvid.NEST.Plugin.Sample;

[ApiController]
[Route ("/")]
public class WeatherForecastController : ControllerBase {
    private readonly WeeklyForecast _weekly = new ();

    [HttpGet ("weekly")]
    public WeeklyForecast Weekly () => _weekly;
}
