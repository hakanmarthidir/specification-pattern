using Microsoft.EntityFrameworkCore;
using specification_pattern.Domain;

namespace specification_pattern.Infrastructure.Persistence
{
    public class SpecificationDbContext:DbContext
    {
        public DbSet<Student> Students { get; set; }

        public SpecificationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
