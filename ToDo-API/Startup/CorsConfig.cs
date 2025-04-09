namespace ToDo_API.Startup
{
    public static class CorsConfig
    {
        public static void ConfigureCors(this WebApplication app)
        {
            app.UseCors(options =>
                options.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader());
        }
    }
}
