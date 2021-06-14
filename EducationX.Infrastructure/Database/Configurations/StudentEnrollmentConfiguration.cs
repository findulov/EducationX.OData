using EducationX.Domain.Entities;
using EducationX.Infrastructure.Database.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationX.Infrastructure.Database.Configurations
{
    public class StudentEnrollmentConfiguration : IEntityTypeConfiguration<StudentEnrollment>
    {
        public void Configure(EntityTypeBuilder<StudentEnrollment> builder)
        {
            builder.HasData(((IDataSeeder<StudentEnrollment>)new DataSeeder()).Seed());
        }
    }
}
