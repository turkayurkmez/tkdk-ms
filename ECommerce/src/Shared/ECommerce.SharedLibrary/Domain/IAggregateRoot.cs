using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.SharedLibrary.Domain
{
    public interface IAggregateRoot
    {
        //Amacım; aggregate standartlarını belirlemek!
        //Dikkat... Tüm aggregate'ler üzerinde olay fırlatabileceğine karar verdik

        IReadOnlyCollection<IDomainEvent> DomainEvents { get; }

        void ClearDomainEvents();
    }
}
