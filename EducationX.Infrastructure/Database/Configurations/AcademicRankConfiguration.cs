using EducationX.Domain.Entities;
using EducationX.Infrastructure.Database.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationX.Infrastructure.Database.Configurations
{
    public class AcademicRankConfiguration : IEntityTypeConfiguration<AcademicRank>
    {
        public void Configure(EntityTypeBuilder<AcademicRank> builder)
        {
            builder.Property(a => a.Name).HasMaxLength(200);

            builder.HasData(((IDataSeeder<AcademicRank>)new DataSeeder()).Seed());
        }
    }
}
