using Microsoft.EntityFrameworkCore;
using ToDo_API.Data;

namespace ToDo_API.Repositorys.ToDoTasks
{
    public class ToDoTasksRepository : IToDoTasksRepository
    {
        private readonly ToDoDbContext _context;
        public ToDoTasksRepository(ToDoDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Models.ToDoTask todotask)
        {
            await _context.Tasks.AddAsync(todotask);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var todoTask = await GetByIdAsync(id);
            if (todoTask != null)
            {
                _context.Tasks.Remove(todoTask);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            bool existe = await _context.Tasks.AnyAsync(x => x.Id == id);
            return existe;
        }

        public async Task<IEnumerable<Models.ToDoTask?>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }

        public async Task<Models.ToDoTask?> GetByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public Task UpdateAsync(Models.ToDoTask todotask)
        {
            _context.Tasks.Update(todotask);
            return _context.SaveChangesAsync();
        }
    }
}
