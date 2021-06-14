using EducationX.Domain.Entities;
using EducationX.Infrastructure.Database;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EducationX.Infrastructure.Queries
{
    public class GetStudentsQuery : IRequestHandler<GetStudentsQueryRequest, IQueryable<Student>>
    {
        private readonly EducationXDbContext dbContext;

        public GetStudentsQuery(EducationXDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<IQueryable<Student>> Handle(GetStudentsQueryRequest request, CancellationToken cancellationToken) =>
            Task.FromResult(dbContext.Students.AsQueryable());
    }

    public class GetStudentsQueryRequest : IRequest<IQueryable<Student>>
    {
    }
}
