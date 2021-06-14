using EducationX.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationX.Infrastructure.Tests.Database
{
    public class InMemoryDbContext : DbContext
    {
        private InMemoryDbContext(DbContextOptions options) : base(options)
        {
        }

        public static InMemoryDbContext Create()
        {
            var options = new DbContextOptionsBuilder<InMemoryDbContext>()
               .UseInMemoryDatabase(databaseName: "EducationXMemoryDatabase")
               .Options;

            return new InMemoryDbContext(options);
        }

        public DbSet<AcademicRank> AcademicRanks { get; set; }
    }
}
