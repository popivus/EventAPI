using EventAPI.Features.Event;
using EventAPI.Features.Ticket;

namespace EventAPI.Services.Interfaces
{
    public interface IEventDatabaseService
    {
        public Task<IEnumerable<IEvent>> Get();
        public Task Add(IEvent eEvent);
        public Task Update(IEvent eEvent);
        public Task Delete(Guid idEvent);
        public Task AddTicket(ITicket ticket, Guid EventId);
    }
}
