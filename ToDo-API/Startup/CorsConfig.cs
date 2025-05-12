namespace ToDo_API.Startup
{
    public static class CorsConfig
    {
        private const string CorsPolicyName = "AllowVercelAndLocalhost";

        public static void AddCorsPolicy(this IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(name: CorsPolicyName, policy =>
                {
                    policy.WithOrigins(
                            "http://localhost:4200",
                            "https://seu-projeto.vercel.app" 
                        )
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });
        }

        public static void UseConfiguredCors(this WebApplication app)
        {
            app.UseCors(CorsPolicyName);
        }
    }
}
