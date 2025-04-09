using ToDo_API.Repositorys.Groups;
using ToDo_API.Repositorys.ToDoTasks;
using ToDo_API.Services.Groups;
using ToDo_API.Services.ToDoTasks;

namespace ToDo_API.Startup
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IToDoTasksService, ToDoTasksService>();
            services.AddScoped<IToDoTasksRepository, ToDoTasksRepository>();
            services.AddScoped<IGroupsService, GroupsService>();
            services.AddScoped<IGroupsRepository, GroupsRepository>();
        }
    }
}
