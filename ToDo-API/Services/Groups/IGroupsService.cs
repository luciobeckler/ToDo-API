namespace ToDo_API.Services.Groups
{
    public interface IGroupsService
    {
        Task<IEnumerable<Models.Group>> GetAllAsync(string userId);
        Task<Models.Group?> GetById(int id, string userId);
        Task AddAsync(Models.Group group);
        Task UpdateAsync(Models.Group group);
        Task DeleteByIdAsync(int id, string userId);
    }
}
