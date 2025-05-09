using Microsoft.EntityFrameworkCore;
using ToDo_API.Data;

namespace ToDo_API.Startup
{
    public static class DbContextConfig
    {
        public static void RegisterDbContext( this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment environment)
        {
            var connectionName = environment.IsDevelopment() ? "DevConnection" : "ProdConnection";
            var connectionString = configuration.GetConnectionString(connectionName);

            services.AddDbContext<ToDoDbContext>(options =>
                options.UseSqlServer(connectionString));
        }
    }
}
