using EducationX.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace EducationX.Infrastructure.Database
{
    public class EducationXDbContext : DbContext
    {
        public EducationXDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<StudentEnrollment> StudentEnrollments { get; set; }
        public DbSet<StudentGrade> StudentGrades { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<AcademicRank> AcademicRanks { get; set; }
    }
}
