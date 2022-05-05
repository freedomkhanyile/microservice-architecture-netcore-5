using MediatR;
using Microsoft.EntityFrameworkCore;
using Student.Microservice.Application.Helpers.Extensions;
using Student.Microservice.Application.ViewModel;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Microservice.Application.Features.Queries
{
    public class GetStudentByIdNumberQuery : IRequest<StudentViewModel>
    {
        public string IdNumber { get; set; }
    }

    public class GetStudentByIdNumberQueryHandler : IRequestHandler<GetStudentByIdNumberQuery, StudentViewModel>
    {
        private readonly IStudentDbContext _context;

        public GetStudentByIdNumberQueryHandler(IStudentDbContext context)
        {
            _context = context;
        }

        public async Task<StudentViewModel> Handle(GetStudentByIdNumberQuery query, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.IdNumber == query.IdNumber);

            if (student == null) return null;

            return student.ToModel();
        }
    }
}
