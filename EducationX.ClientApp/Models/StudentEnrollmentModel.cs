using System;

namespace EducationX.ClientApp.Models
{
    public class StudentEnrollmentModel
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int CourseId { get; set; }
        public DateTime DateEnrolled { get; set; }
        public CourseModel Course { get; set; }
    }
}
