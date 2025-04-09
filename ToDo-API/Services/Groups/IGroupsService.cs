namespace ToDo_API.Services.Groups
{
    public interface IGroupsService
    {
        Task<IEnumerable<Models.Group>> GetAllAsync();
        Task<Models.Group?> GetByIdAsync(int id);
        Task AddAsync(Models.Group group);
        Task UpdateAsync(Models.Group group);
        Task DeleteAsync(int id);
    }
}
