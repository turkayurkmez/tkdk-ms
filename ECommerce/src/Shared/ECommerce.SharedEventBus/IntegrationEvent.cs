namespace ECommerce.SharedEventBus
{
    public record IntegrationEvent
    {
        public Guid Id {  get; init; }
        public DateTime CreatedDate { get; init; }

        public IntegrationEvent()
        {
            Id = Guid.NewGuid();
            CreatedDate = DateTime.UtcNow;
        }
    }
}
