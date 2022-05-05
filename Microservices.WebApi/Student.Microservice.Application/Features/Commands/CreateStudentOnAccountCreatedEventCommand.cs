using MediatR;
using Student.Microservice.Application.Helpers.Exceptions;
using Student.Microservice.Application.Helpers.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Student.Microservice.Application.Features.Commands
{
    public class CreateStudentOnAccountCreatedEventCommand : IRequest<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string CellNumber { get; set; }
        public string Ethnicity { get; set; }
        public string HomeLanguage { get; set; }
        [Required]
        public string IdNumber { get; set; }

        [Required]
        public int AccountId { get; set; }

        [MaxLength(256)]
        public string CreateUserId { get; set; }

        [MaxLength(256)]
        public string ModifyUserId { get; set; }
        public bool IsActive { get; set; } = true;
        public int StatusId { get; set; }
    }

    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentOnAccountCreatedEventCommand, int>
    {
        private readonly IStudentDbContext _context;

        public CreateStudentCommandHandler(IStudentDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateStudentOnAccountCreatedEventCommand command, CancellationToken cancellationToken)
        {

            try
            {
                var studentToCreate = command.ToEntity();

                // add student
                await _context.Students.AddAsync(studentToCreate);
                await _context.SaveChangesAsync();

                if (studentToCreate.Id == 0) return default;

                return studentToCreate.Id;
            }
            catch (Exception ex)
            {
                throw new AppException(ex.Message);
            }
        }
    }
}
