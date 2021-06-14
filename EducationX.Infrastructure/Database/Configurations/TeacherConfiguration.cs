using EducationX.Domain.Entities;
using EducationX.Infrastructure.Database.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationX.Infrastructure.Database.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.ToTable("Teachers");

            builder.HasData(((IDataSeeder<Teacher>)new DataSeeder()).Seed());
        }
    }
}
