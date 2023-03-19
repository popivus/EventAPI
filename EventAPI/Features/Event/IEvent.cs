using EventAPI.Features.Ticket;
using Swashbuckle.AspNetCore.Annotations;

namespace EventAPI.Features.Event
{
    public interface IEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public Guid ImageId { get; set; }
        public Guid SpaceId { get; set; }
        public IEnumerable<ITicket> Tickets { get; set; }
        public bool Availability { get; set; }
    }
}
