using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Application
{
    public class JwtTokenSettings
    {
        //Secret, Issuer, Audience, AccessTokenExpirationMinutes, RefreshTokenExpirationDays
        public string Secret { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public int AccessTokenExpirationMinutes { get; set; } = 60; // Default to 1 hour
        public int AccessTokenExpirationDays { get; set; } = 3600; // Default to 1 hour in seconds

    }
}
