using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.SharedLibrary.Domain
{
    public abstract class DomainEvent : IDomainEvent
    {
        public Guid Id { get; protected set; }

        public DateTime OccuredOn {  get; protected set; }

        protected DomainEvent()
        {
            Id = Guid.NewGuid();
            OccuredOn = DateTime.UtcNow;
        }
    }
}
