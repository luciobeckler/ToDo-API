using Microsoft.EntityFrameworkCore;
using ToDo_API.Models;

namespace ToDo_API.Data
{
    public class ToDoDbContext : DbContext
    {
        public ToDoDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ToDoTask> Tasks { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
