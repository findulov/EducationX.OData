using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace EducationX.Infrastructure.Handlers
{
    public class AddGradeForStudentHandler : AsyncRequestHandler<AddGradeForStudentRequest>
    {
        protected override Task Handle(AddGradeForStudentRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public class AddGradeForStudentRequest : IRequest
    {
    }
}
