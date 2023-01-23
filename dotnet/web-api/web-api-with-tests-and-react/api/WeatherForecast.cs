namespace api;

public class WeatherForecast
{
    private readonly TestStructure test = new TestStructure();
    public WeatherForecast(TestStructure _test)
    {
        test = _test;
    }
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }

    void Change()
    {
        test = new TestStructure();
    }

}


public struct TestStructure
{
    public TestStructure(int id, string name, WeatherForecast forecast)
    {
        Id = id;
        Name = name;
        Forecast = forecast;
    }
    public int Id { get; set; }
    public readonly string Name { get; init; }
    public WeatherForecast Forecast { get; set; }
}