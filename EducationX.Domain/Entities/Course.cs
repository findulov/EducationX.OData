using System.Collections.Generic;

namespace EducationX.Domain.Entities
{
    public class Course
    {
        public Course(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TeacherCourse> CourseTeachers { get; set; }
    }
}
