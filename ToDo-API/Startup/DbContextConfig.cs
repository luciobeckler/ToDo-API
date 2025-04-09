using Microsoft.EntityFrameworkCore;
using ToDo_API.Data;

namespace ToDo_API.Startup
{
    public static class DbContextConfig
    {
        public static void RegisterDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ToDoDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DevConnection")));
        }
    }
}
