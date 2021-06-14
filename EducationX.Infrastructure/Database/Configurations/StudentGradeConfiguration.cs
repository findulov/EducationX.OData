using EducationX.Domain.Entities;
using EducationX.Infrastructure.Database.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationX.Infrastructure.Database.Configurations
{
    public class StudentGradeConfiguration : IEntityTypeConfiguration<StudentGrade>
    {
        public void Configure(EntityTypeBuilder<StudentGrade> builder)
        {
            builder.HasCheckConstraint("CK_StudentGrade_Grade", "[Grade] BETWEEN 1 AND 100");

            builder.HasData(((IDataSeeder<StudentGrade>)new DataSeeder()).Seed());
        }
    }
}
