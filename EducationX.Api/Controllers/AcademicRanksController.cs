using EducationX.Domain.Entities;
using EducationX.Infrastructure.Queries;
using MediatR;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace EducationX.Api.Controllers
{
    [ODataRoutePrefix("academic-ranks")]
    public class AcademicRanksController : ODataController
    {
        private readonly IMediator mediator;

        public AcademicRanksController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [EnableQuery]
        [ODataRoute]
        public async Task<IQueryable<AcademicRank>> Get()
        {
            return await mediator.Send(new GetAcademicRanksRequest());
        }
    }
}
