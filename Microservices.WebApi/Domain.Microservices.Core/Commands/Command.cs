using Domain.Microservices.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Microservices.Core.Commands
{
    public class Command : Message
    {
        public DateTime Time { get; protected set; }

        protected Command()
        {
            Time = DateTime.Now;    
        }
    }
}
