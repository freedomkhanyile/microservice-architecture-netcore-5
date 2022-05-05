using MediatR;
using Microsoft.EntityFrameworkCore;
using Student.Microservice.Application.Helpers.Extensions;
using Student.Microservice.Application.ViewModel;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Microservice.Application.Features.Queries
{
    public class GetStudentByIdQuery : IRequest<StudentViewModel>
    {
        public int StudentId { get; set; }
    }
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQuery, StudentViewModel>
    {
        private readonly IStudentDbContext _context;

        public GetStudentByIdQueryHandler(IStudentDbContext context)
        {
            _context = context;
        }

        public async Task<StudentViewModel> Handle(GetStudentByIdQuery query, CancellationToken cancellationToken)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == query.StudentId);
            if (student == null) return null;
            return student.ToModel();
        }
    }
}
