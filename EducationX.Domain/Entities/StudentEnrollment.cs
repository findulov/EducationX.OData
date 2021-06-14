using System;

namespace EducationX.Domain.Entities
{
    public class StudentEnrollment
    {
        public StudentEnrollment()
        {
        }

        public StudentEnrollment(int studentId, int courseId)
        {
            StudentId = studentId;
            CourseId = courseId;
            DateEnrolled = DateTime.UtcNow;
        }

        public StudentEnrollment(int id, int studentId, int courseId, DateTime dateEnrolled)
        {
            Id = id;
            StudentId = studentId;
            CourseId = courseId;
            DateEnrolled = dateEnrolled;
        }

        public int Id { get; set; }

        public int StudentId { get; set; }

        public int CourseId { get; set; }

        public DateTime DateEnrolled { get; set; }

        public Student Student { get; set; }

        public Course Course { get; set; }
    }
}
