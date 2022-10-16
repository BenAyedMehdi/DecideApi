using DecideApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DecideApi.Data
{
    public class DecisionsDbContext:DbContext
    {
        public DecisionsDbContext(DbContextOptions<DecisionsDbContext> options): base(options)
        {
        }

        public DbSet<Decision> Decisions { get; set; }
        public DbSet<Pro> Pros { get; set; }
        public DbSet<Conn> Cons { get; set; }

    }
}
