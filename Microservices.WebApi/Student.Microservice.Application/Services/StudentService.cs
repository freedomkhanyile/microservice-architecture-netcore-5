using Domain.Microservices.Core.Bus;
using MediatR;
using Student.Microservice.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student.Microservice.Application.Services
{
    public interface IStudentService
    {
        Task<int> CreateStudentFromAccountEvent(CreatedAccountEventViewModel model);
    }

    public class StudentService : IStudentService
    {
        private readonly IEventBus _bus;
        public StudentService(IMediator mediator, IEventBus bus)
        {
            _bus = bus;
        }

        public async Task<int> CreateStudentFromAccountEvent(CreatedAccountEventViewModel model)
        {
            return await Task.FromResult(1);
        }
    }
}
