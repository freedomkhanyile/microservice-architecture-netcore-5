using Domain.Microservices.Core.Commands;
using Domain.Microservices.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Microservices.Core.Bus
{
    public interface IEventBus
    {
        Task SendCommand<T>(T command) where T : Command;

        void Publish<T>(T @event) where T: Event;

        void Subscribe<T, TH>() where T : Event where TH : IEventHandler<T>;
    }
}
