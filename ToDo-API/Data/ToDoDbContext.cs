using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ToDo_API.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ToDo_API.Data
{
    public class ToDoDbContext : IdentityDbContext<ApplicationUser>
    {
        public ToDoDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Group>()
                .HasOne(g => g.User)
                .WithMany(u => u.Groups)
                .HasForeignKey(g => g.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }

        public DbSet<ToDoTask> Tasks { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
