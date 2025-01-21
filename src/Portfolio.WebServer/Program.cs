using Portfolio.WebServer.Filters;

var builder = WebApplication.CreateBuilder(args);
var isDevelopment = builder.Environment.IsDevelopment();
builder.Services.AddSingleton<IStartupFilter, PathBaseStartupFilter>();
if (isDevelopment)
{
    // Add services to the container.
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddPostgresSQL(builder.Configuration);
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("AllowLocalhost",
            policy =>
            {
                policy
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .WithOrigins("http://localhost:5173");
            });
    });
    //builder.Services.Configure<JsonOptions>(options =>
    //{
    //    options.SerializerOptions.PropertyNamingPolicy = null;
    //});
}
var app = builder.Build();

// Configure the HTTP request pipeline.
if (isDevelopment)
{
    app.UseSwagger();
    app.UseSwaggerUI();
    // Use CORS middleware
    app.UseCors("AllowLocalhost");
}

app.UseHttpsRedirection();
app.UseDefaultFiles();
app.UseStaticFiles();
// Serve default files like index.html  
app.MapWeatherforecastEndpoints();

// TODO - this is temporary work this is just a starting point to finish the PR
// using var applicationScope = app.Services.CreateScope();
// var sqlCheck = applicationScope.ServiceProvider.GetRequiredService<SqlConnectionHealthCheck>();
// await sqlCheck.ConnectAsync();

await app.RunAsync();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
