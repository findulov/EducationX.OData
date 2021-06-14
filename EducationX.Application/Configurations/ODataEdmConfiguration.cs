using EducationX.Domain.Entities;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;

namespace EducationX.Application.Configurations
{
    public static class ODataEdmConfiguration
    {
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder()
                .RegisterStudents()
                .RegisterStudentGrades()
                .RegisterAcademicRanks();

            return builder.GetEdmModel();
        }

        private static ODataConventionModelBuilder RegisterStudents(this ODataConventionModelBuilder builder)
        {
            EntitySetConfiguration<Student> entitySet = builder.EntitySet<Student>("students");
            entitySet.EntityType.HasKey(entity => entity.Id);

            return builder;
        }

        private static ODataConventionModelBuilder RegisterStudentGrades(this ODataConventionModelBuilder builder)
        {
            EntitySetConfiguration<StudentGrade> entitySet = builder.EntitySet<StudentGrade>("student-grades");
            entitySet.EntityType.HasKey(entity => entity.Id);

            return builder;
        }

        private static ODataConventionModelBuilder RegisterAcademicRanks(this ODataConventionModelBuilder builder)
        {
            EntitySetConfiguration<StudentGrade> entitySet = builder.EntitySet<StudentGrade>("academic-ranks");
            entitySet.EntityType.HasKey(entity => entity.Id);

            return builder;
        }
    }
}
