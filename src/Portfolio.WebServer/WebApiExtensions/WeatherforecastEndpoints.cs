namespace Microsoft.Extensions.DependencyInjection
{
    public static class WeatherforecastEndpoints
    {
        public static readonly IEnumerable<string> summaries = [
            "Freezing",
            "Bracing",
            "Chilly",
            "Cool",
            "Mild",
            "Warm",
            "Balmy",
            "Hot",
            "Sweltering",
            "Scorching"
        ];

        public static readonly int summaryCount = summaries.Count();

        public static void MapWeatherforecastEndpoints(this IEndpointRouteBuilder endpoints)
        {
            var weatherforecastRoutes = endpoints
                .MapGroup("weatherforecast");

            // root route
            weatherforecastRoutes.MapGet(string.Empty, async (ILoggerFactory loggerFactory, CancellationToken cancellationToken = default) =>
                {
                    var logger = loggerFactory.CreateLogger("Get Weatherforecast Endpoint");
                    logger.LogInformation("Weatherforecast request is starting...");
                    cancellationToken.Register(() =>
                    {
                        logger.LogInformation("Weatherforecast request was cancelled");
                    });


                    await Task.Delay(2_000, cancellationToken);
                    var forecast = Enumerable.Range(1, 5)
                    .Select(index =>
                        new WeatherForecast
                        (
                            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                            Random.Shared.Next(-20, 55),
                            summaries.ElementAt(Random.Shared.Next(summaryCount))
                        ))
                        .ToArray();
                    logger.LogInformation("Weatherforecast API was successful");
                    // logger.LogInformation("forecasts: {@forecast}", System.Text.Json.JsonSerializer.Serialize(forecast));
                    return Results.Ok(forecast);
                })
                .WithName("GetWeatherForecast")
                .WithOpenApi();
        }
    }
}