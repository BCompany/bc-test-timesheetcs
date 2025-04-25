namespace bc_test_timesheetcs.Api
{
    public class WeatherForecast
    {
        public DateTime Date1 { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}