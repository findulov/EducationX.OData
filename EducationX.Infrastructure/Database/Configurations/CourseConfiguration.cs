using EducationX.Domain.Entities;
using EducationX.Infrastructure.Database.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationX.Infrastructure.Database.Configurations
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(200);

            builder.HasData(((IDataSeeder<Course>)new DataSeeder()).Seed());
        }
    }
}
