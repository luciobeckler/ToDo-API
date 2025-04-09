namespace ToDo_API.Repositorys.Groups
{
    public interface IGroupsRepository
    {
        Task<List<Models.Group>> GetAllAsync();
        Task<Models.Group?> GetByIdAsync(int id);
        Task AddAsync(Models.Group group);
        Task UpdateAsync(Models.Group group);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
