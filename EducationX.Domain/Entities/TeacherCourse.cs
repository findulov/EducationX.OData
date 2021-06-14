namespace EducationX.Domain.Entities
{
    public class TeacherCourse
    {
        public TeacherCourse()
        {
        }

        public TeacherCourse(int teacherId, int courseId)
        {
            TeacherId = teacherId;
            CourseId = courseId;
        }

        public int TeacherId { get; set; }

        public int CourseId { get; set; }

        public Teacher Teacher { get; set; }

        public Course Course { get; set; }
    }
}
