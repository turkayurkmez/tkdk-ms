using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Service.Application
{
    public record AuthResponseDto
    {
        public string AccessToken { get; init; } = string.Empty;
        public string RefreshToken { get; init; } = string.Empty;

        public DateTime ExpiresAt { get; init; }
        public UserDto User { get; init; } 
    }
}
