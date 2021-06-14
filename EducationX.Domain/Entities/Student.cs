using System;
using System.Collections.Generic;

namespace EducationX.Domain.Entities
{
    public class Student : User
    {
        public Student()
        {
        }

        public Student(int id, string firstName, string lastName, DateTime birthDate)
            : base(id, firstName, lastName, birthDate)
        {
        }

        public ICollection<StudentEnrollment> EnrolledCourses { get; set; }

        public void EnrollInCourse(int courseId)
        {
            EnrolledCourses.Add(new StudentEnrollment
            {
                CourseId = courseId,
                DateEnrolled = DateTime.UtcNow
            });
        }
    }
}
