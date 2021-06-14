using System;

namespace EducationX.ClientApp.Models
{
    public class StudentGradeModel
    {
        public int Id { get; set; }
        public int StudentEnrollmentId { get; set; }
        public int Grade { get; set; }
        public DateTime DateCreated { get; set; }
        public StudentEnrollmentModel StudentEnrollment { get; set; }
    }
}
