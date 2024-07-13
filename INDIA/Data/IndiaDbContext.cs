using INDIA.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace INDIA.Data
{
    public class IndiaDbContext: DbContext
    {
        public IndiaDbContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
            
        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<State> States { get; set; }
    }
}
