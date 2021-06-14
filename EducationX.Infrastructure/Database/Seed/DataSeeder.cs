using EducationX.Domain.Entities;
using System;
using System.Collections.Generic;

namespace EducationX.Infrastructure.Database.Seed
{
    public class DataSeeder : 
        IDataSeeder<AcademicRank>,
        IDataSeeder<Course>,
        IDataSeeder<Student>,
        IDataSeeder<Teacher>,
        IDataSeeder<TeacherCourse>,
        IDataSeeder<StudentEnrollment>,
        IDataSeeder<StudentGrade>
    {
        IEnumerable<AcademicRank> IDataSeeder<AcademicRank>.Seed() => new List<AcademicRank>
        {
            new AcademicRank(1, "Professor"),
            new AcademicRank(2, "Associate professor"),
            new AcademicRank(3, "Assistant Professor"),
            new AcademicRank(4, "Lecturer"),
        };

        IEnumerable<Course> IDataSeeder<Course>.Seed() => new List<Course>        
        {
            new Course(1, "Math"),
            new Course(2, "Physics"),
            new Course(3, "Acting classes"),
            new Course(4, "Paleontology")
        };

        IEnumerable<Teacher> IDataSeeder<Teacher>.Seed() => new List<Teacher>
        {
            new Teacher(1, "Joey", "Tribbiani", birthDate: new DateTime(1967, 01, 01), academicRankId: 4),
            new Teacher(2, "Ross", "Geller", birthDate: new DateTime(1967, 01, 01), academicRankId: 1),
            new Teacher(3, "Evelyn", "Harper", birthDate: new DateTime(1980, 05, 06), academicRankId: 1)
        };
        public IEnumerable<TeacherCourse> Seed() => new List<TeacherCourse>
        {
            new TeacherCourse(teacherId: 1, courseId: 3),
            new TeacherCourse(teacherId: 2, courseId: 4),
            new TeacherCourse(teacherId: 3, courseId: 1),
            new TeacherCourse(teacherId: 3, courseId: 2),
        };

        IEnumerable<Student> IDataSeeder<Student>.Seed() => new List<Student>
        {
            new Student(4, "Georgi", "Findulov", birthDate: new DateTime(1993, 09, 11)),
            new Student(5, "John", "Smith", birthDate: new DateTime(1990, 08, 18)),
            new Student(6, "Mark", "Johnson", birthDate: new DateTime(1999, 05, 12)),
            new Student(7, "Charlotte", "Williams", birthDate: new DateTime(1997, 03, 22))
        };

        IEnumerable<StudentEnrollment> IDataSeeder<StudentEnrollment>.Seed() => new List<StudentEnrollment>
        {
            new StudentEnrollment(1, studentId: 4, courseId: 1, dateEnrolled: DateTime.UtcNow),
            new StudentEnrollment(2, studentId: 4, courseId: 2, dateEnrolled: DateTime.UtcNow.AddDays(-90)),
            new StudentEnrollment(3, studentId: 5, courseId: 3, dateEnrolled: DateTime.UtcNow.AddDays(-120)),
            new StudentEnrollment(4, studentId: 6, courseId: 4, dateEnrolled: DateTime.UtcNow.AddDays(-87)),
            new StudentEnrollment(5, studentId: 7, courseId: 3, dateEnrolled: DateTime.UtcNow.AddYears(-1).AddDays(-38))
        };

        IEnumerable<StudentGrade> IDataSeeder<StudentGrade>.Seed() => new List<StudentGrade>
        {
            new StudentGrade(1, studentEnrollmentId: 1, grade: (byte)new Random().Next(1, 100)),
            new StudentGrade(2, studentEnrollmentId: 1, grade: (byte)new Random().Next(1, 100)),
            new StudentGrade(3, studentEnrollmentId: 2, grade: (byte)new Random().Next(1, 100)),
            new StudentGrade(4, studentEnrollmentId: 2, grade: (byte)new Random().Next(1, 100)),
            new StudentGrade(5, studentEnrollmentId: 4, grade: (byte)new Random().Next(1, 100)),
            new StudentGrade(6, studentEnrollmentId: 3, grade: (byte)new Random().Next(1, 100)),
            new StudentGrade(7, studentEnrollmentId: 5, grade: (byte)new Random().Next(1, 100))
        };
    }
}
