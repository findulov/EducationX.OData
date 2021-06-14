using EducationX.Domain.Entities;
using EducationX.Infrastructure.Database;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EducationX.Infrastructure.Queries
{
    public class GetStudentGradesInfoQuery : IRequestHandler<GetStudentGradesInfoQueryRequest, IQueryable<StudentGrade>>
    {
        private readonly EducationXDbContext dbContext;

        public GetStudentGradesInfoQuery(EducationXDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<IQueryable<StudentGrade>> Handle(GetStudentGradesInfoQueryRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(dbContext.StudentGrades
                .Include(sg => sg.StudentEnrollment)
                    .ThenInclude(se => se.Course)
                        .ThenInclude(c => c.CourseTeachers)
                            .ThenInclude(ct => ct.Teacher)
                .Include(sg => sg.StudentEnrollment.Student)
                .AsQueryable());
        }
    }

    public class GetStudentGradesInfoQueryRequest : IRequest<IQueryable<StudentGrade>>
    {
    }
}
