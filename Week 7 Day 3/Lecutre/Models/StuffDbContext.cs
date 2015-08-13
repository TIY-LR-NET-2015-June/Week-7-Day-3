using System.Data.Entity;

namespace Lecutre.Models
{
    public class StuffDbContext : DbContext
    {
        public StuffDbContext()
            : base("name=StuffDbContext")
        {
        }

        public DbSet<PeopleImage> PeopleImages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}