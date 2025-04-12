using Microsoft.EntityFrameworkCore;
using ToDo_API.Data;

namespace ToDo_API.Repositorys.Groups
{
    public class GroupsRepository : IGroupsRepository
    {
        private readonly ToDoDbContext _context;
        public GroupsRepository(ToDoDbContext context)
        {
            _context = context;
        }
        public async Task<List<Models.Group>> GetAllAsync()
        {
            return await _context.Groups.Include(x => x.Tasks).ToListAsync();
        }
        public async Task<Models.Group?> GetByIdAsync(int id)
        {
            return await _context.Groups.Include(x => x.Tasks).FirstOrDefaultAsync(t => t.Id == id);
        }
        public async Task AddAsync(Models.Group group)
        {
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
        }
        public Task UpdateAsync(Models.Group group)
        {
            _context.Entry(group).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var group = await GetByIdAsync(id);
            if (group != null)
            {
                _context.Groups.Remove(group);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            bool existe = await _context.Groups.AnyAsync(x => x.Id == id);
            return existe;
        }

        public async Task<bool> ExistsByTitleAsync(string title)
        {
            bool existe = await _context.Groups.AnyAsync(x => x.Title == title);
            return existe;
        }
        public async Task<Models.Group?> GetByTitleAsync(string title)
        {
            return await _context.Groups.FirstOrDefaultAsync(g => g.Title == title);
        }

    }
}
