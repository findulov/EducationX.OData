using System;
using System.Collections.Generic;
using System.Linq;

namespace EducationX.Domain.Entities
{
    public class Teacher : User
    {
        public Teacher()
        {
        }

        public Teacher(int id, string firstName, string lastName, DateTime birthDate, int academicRankId)
            : base(id, firstName, lastName, birthDate)
        {
            AcademicRankId = academicRankId;
        }

        public int AcademicRankId { get; set; }

        public AcademicRank AcademicRank { get; set; }

        public ICollection<TeacherCourse> Courses { get; set; }
    }
}
