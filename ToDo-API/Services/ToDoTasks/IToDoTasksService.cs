namespace ToDo_API.Services.ToDoTasks
{
    public interface IToDoTasksService
    {
        Task<IEnumerable<Models.ToDoTask>> GetAllAsync();
        Task<Models.ToDoTask?> GetByIdAsync(int id);
        Task AddAsync(Models.ToDoTask toDoTask);
        Task UpdateAsync(Models.ToDoTask toDoTask);
        Task DeleteAsync(int id);
    }
}
