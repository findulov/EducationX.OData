using EducationX.Domain.Entities;
using EducationX.Infrastructure.Database.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EducationX.Infrastructure.Database.Configurations
{
    public class TeacherCourseConfiguration : IEntityTypeConfiguration<TeacherCourse>
    {
        public void Configure(EntityTypeBuilder<TeacherCourse> builder)
        {
            builder.HasKey(tc => new { tc.TeacherId, tc.CourseId });

            builder.HasData(((IDataSeeder<TeacherCourse>)new DataSeeder()).Seed());
        }
    }
}
