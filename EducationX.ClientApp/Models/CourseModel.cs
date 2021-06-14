using System.Collections.Generic;

namespace EducationX.ClientApp.Models
{
    public class CourseModel
    {
        public string Name { get; set; }
        public List<CourseTeacherModel> CourseTeachers { get; set; }
    }
}
