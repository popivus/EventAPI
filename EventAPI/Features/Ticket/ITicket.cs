namespace EventAPI.Features.Ticket
{
    public interface ITicket
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Place { get; set; }
    }
}
