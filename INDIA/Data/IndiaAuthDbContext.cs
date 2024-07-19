using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace INDIA.Data
{
    public class IndiaAuthDbContext : IdentityDbContext
    {
        public IndiaAuthDbContext(DbContextOptions<IndiaAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerId = "fee0a198-70c4-4c48-9975-708ade77f894";
            var writerId = "616872a7-3644-4ce9-b143-e7a77ff92b64";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerId,
                    ConcurrencyStamp = readerId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()

                },
                new IdentityRole
                {
                    Id = writerId,
                    ConcurrencyStamp = writerId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()

                }

            };

            builder.Entity<IdentityRole>().HasData(roles);
        }

    }
}
