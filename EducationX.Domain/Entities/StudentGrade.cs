using System;

namespace EducationX.Domain.Entities
{
    public class StudentGrade
    {
        public StudentGrade()
        {
        }

        public StudentGrade(int id, int studentEnrollmentId, byte grade)
        {
            Id = id;
            StudentEnrollmentId = studentEnrollmentId;
            Grade = grade;
            DateCreated = DateTime.UtcNow;
        }

        public StudentGrade(int id, int studentEnrollmentId, byte grade, DateTime dateCreated)
            : this(id, studentEnrollmentId, grade)
        {
            DateCreated = dateCreated;
        }

        public int Id { get; set; }

        public int StudentEnrollmentId { get; set; }

        /// <summary>
        /// Gets or sets a value specying the grade of a student for a specific course. 
        /// The grade consists of a value between 1 and 100.
        /// </summary>
        public byte Grade { get; set; }

        public DateTime DateCreated { get; set; }

        public StudentEnrollment StudentEnrollment { get; set; }
    }
}
