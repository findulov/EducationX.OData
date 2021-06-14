using EducationX.Domain.Entities;
using EducationX.Infrastructure.Database;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EducationX.Infrastructure.Queries
{
    public class GetAcademicRanksQuery : IRequestHandler<GetAcademicRanksRequest, IQueryable<AcademicRank>>
    {
        private readonly EducationXDbContext dbContext;

        public GetAcademicRanksQuery(EducationXDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<IQueryable<AcademicRank>> Handle(GetAcademicRanksRequest request, CancellationToken cancellationToken) =>
            Task.FromResult(dbContext.AcademicRanks.AsQueryable());
    }

    public class GetAcademicRanksRequest : IRequest<IQueryable<AcademicRank>>
    {
    }
}
