namespace Portfolio.WebServer.Filters
{
    public class PathBaseStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return app =>
            {
                app.UsePathBase("/api");
                next(app);
            };
        }
    }
}
