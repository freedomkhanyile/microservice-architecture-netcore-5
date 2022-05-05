using MediatR;
using Microsoft.EntityFrameworkCore;
using Student.Microservice.Application.Helpers.Extensions;
using Student.Microservice.Application.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Microservice.Application.Features.Queries
{
    public class GetAllStudentsByStatusQuery : IRequest<List<StudentViewModel>>
    {
        public int StatusId { get; set; }
    }

    public class GetAllStudentsByStatusQueryHandler : IRequestHandler<GetAllStudentsByStatusQuery, List<StudentViewModel>>
    {
        private readonly IStudentDbContext _context;

        public GetAllStudentsByStatusQueryHandler(IStudentDbContext context)
        {
            _context = context;
        }

        public async Task<List<StudentViewModel>> Handle(GetAllStudentsByStatusQuery query, CancellationToken cancellationToken)
        {
            var students = await _context.Students.Where(x => x.StatusId == query.StatusId)
                 .ToListAsync();
            if (students == null) return null;

            return students.AsReadOnly()
                .Select(x => x.ToModel())
                .ToList();
        }
    }
}
