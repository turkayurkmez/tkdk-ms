using ECommerce.SharedLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Identity.Domain
{
    public class User : AggregateRoot<Guid>
    {
        public string UserName { get; private set; }
        public string Email { get; private set; }
        public string PasswordHash { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public bool IsActive { get; private set; }

        // Navigation properties for roles and refresh tokens
        private readonly List<UserRole> _userRoles = new List<UserRole>();
        public IReadOnlyCollection<UserRole> UserRoles => _userRoles.AsReadOnly();

        private readonly List<RefreshToken> _refreshTokens = new List<RefreshToken>();
        public IReadOnlyCollection<RefreshToken> RefreshTokens => _refreshTokens.AsReadOnly();
        public User(string userName, string email, string passwordHash, string firstName, string lastName)
        {
            UserName = userName;
            Email = email;
            PasswordHash = passwordHash;
            FirstName = firstName;
            LastName = lastName;
            IsActive = true;
        }
        // Additional methods for updating user details, activating/deactivating user, etc. can be added here

        //EF Core constructor for EF Core
        protected User() { }
    }
}
