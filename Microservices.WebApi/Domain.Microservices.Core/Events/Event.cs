using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Microservices.Core.Events
{
    public abstract class Event
    {

        public DateTime Time { get; protected set; }

        protected Event()
        {
            Time = DateTime.Now;
        }
    }
}
