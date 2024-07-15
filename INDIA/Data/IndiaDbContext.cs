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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var Languages = new List<Language>
            {
                new Language
                {
                    Id = Guid.Parse("07a4c903-83c1-4d51-8398-94a9ca8905a3"),
                    Name = "Marathi"
                },
                new Language
                {
                    Id = Guid.Parse("77b4897f-5aaf-47b2-9404-6b7b2e60760a"),
                    Name = "Tamil"
                },
                new Language
                {
                    Id = Guid.Parse("64b3bf89-e50f-4297-919a-36194660c9fc"),
                    Name = "Hindi"
                },
                new Language
                {
                    Id = Guid.Parse("1c47dbde-52d9-497d-9f9b-9ccb2cc28dfa"),
                    Name = "Telugu"
                },
                new Language
                {
                    Id = Guid.Parse("5d5992b3-55a4-48ec-b18f-2f9ef4544614"),
                    Name = "Kannada"
                }
            };

            modelBuilder.Entity<Language>().HasData(Languages);

            var Districts = new List<District>
            {
                new District
                {
                    Id = Guid.Parse("47a5276e-5ae0-4c5f-982a-638a5aba10d5"),
                    Name = "Satara",
                    Code = "STRA",
                    AreaInSqrKm = 19829,
                    DistrictImageUrl = "satara/patan.jpeg"
                },
                new District
                {
                    Id = Guid.Parse("04da054a-fe7f-4961-bb72-5342c389bae7"),
                    Name = "Sangali",
                    Code = "SNGL",
                    AreaInSqrKm = 17293,
                    DistrictImageUrl = "sangali/faui.png"
                },
                new District
                {
                    Id = Guid.Parse("02c0ee3c-0734-4bd8-aee0-c891cffaa6d4"),
                    Name = "Pune",
                    Code = "PNQ",
                    AreaInSqrKm = 19999,
                    DistrictImageUrl = "pune/baner.jpg"
                },
                new District
                {
                    Id = Guid.Parse("05536da6-f49d-4dab-80fe-567597c047d8"),
                    Name = "Kolhapur",
                    Code = "KLPR",
                    AreaInSqrKm = 17899,
                    DistrictImageUrl = null
                }
            };

            modelBuilder.Entity<District>().HasData(Districts);
        }
    }
}
