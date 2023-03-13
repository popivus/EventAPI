using EventAPI.Models.Interfaces;

namespace EventAPI.Services.Interfaces
{
    public interface IEventDatabaseService
    {
        public Task<IEnumerable<IEvent>> Get();
        public Task Add(IEvent eEvent);
        public Task Update(IEvent eEvent);
        public Task Delete(Guid idEvent);
    }
}
