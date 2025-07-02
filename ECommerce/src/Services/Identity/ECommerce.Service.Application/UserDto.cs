namespace ECommerce.Service.Application
{
    public record UserDto
    {
        public Guid Id { get; init; }
        public string UserName { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string FirstName { get; init; } = string.Empty;
        public string LastName { get; init; } = string.Empty;
        public bool IsActive { get; init; }

        public List<string> Roles { get; set; } = new List<string>();


    }
}