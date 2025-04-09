namespace ToDo_API.Repositorys.ToDoTasks
{
    public interface IToDoTasksRepository
    {
        Task<IEnumerable<Models.ToDoTask>> GetAllAsync();
        Task<Models.ToDoTask?> GetByIdAsync(int id);
        Task AddAsync(Models.ToDoTask todotask);
        Task UpdateAsync(Models.ToDoTask todotask);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
