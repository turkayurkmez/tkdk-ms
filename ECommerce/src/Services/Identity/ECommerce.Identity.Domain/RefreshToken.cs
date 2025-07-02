using ECommerce.SharedLibrary.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Identity.Domain
{
    public class RefreshToken :AggregateRoot<int>
    {
        public Guid UserId { get; private set; }
        public User User { get; private set; }
        public string Token { get; private set; } = string.Empty;
        public DateTime ExpiryDate { get; private set; }

        //isRevoke:

        // Indicates whether the token is active or has been revoked
        public bool IsRevoked { get; private set; }


        public bool IsActive => IsRevoked && ExpiryDate > DateTime.UtcNow;
        public RefreshToken(Guid userId, string token, DateTime expiration)
        {
            UserId = userId;
            Token = token;
            ExpiryDate = expiration;
           
        }
        // Method to deactivate the token
       public void Revoke()
        {
            IsRevoked = true;

        }
        //EF Core constructor for EF Core
        protected RefreshToken()
        { }
    }
}
