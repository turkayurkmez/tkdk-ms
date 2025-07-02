using ECommerce.SharedLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Identity.Domain
{
    public class Role : AggregateRoot<Guid>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }

        private readonly List<UserRole> _userRoles = new List<UserRole>();
        public IReadOnlyCollection<UserRole> UserRoles => _userRoles.AsReadOnly();
        public Role(string name, string description)
        {
            Name = name;
            Description = description;
        }
        // Additional methods for updating role details can be added here
        //EF Core constructor for EF Core
        protected Role()
        { 
        }
    }
}
