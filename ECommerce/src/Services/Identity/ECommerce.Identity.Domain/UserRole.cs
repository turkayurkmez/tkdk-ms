using ECommerce.SharedLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Identity.Domain
{
    public class UserRole : AggregateRoot<int>
    {
        public Guid UserId { get; private set; }

        public User User { get; private set; }
        public Guid RoleId { get; private set; }
        public Role Role { get; private set; }
        public UserRole(Guid userId, Guid roleId)
        {
            UserId = userId;
            RoleId = roleId;
        }
        //EF Core constructor for EF Core
        protected UserRole()
        { }
    }
}
