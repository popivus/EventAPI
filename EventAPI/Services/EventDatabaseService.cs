using EventAPI.Models;
using EventAPI.Models.Interfaces;
using EventAPI.Services.Interfaces;

namespace EventAPI.Services
{
    public class EventDatabaseService : IEventDatabaseService
    {
        private List<IEvent> _events;

        public EventDatabaseService()
        {
            _events = new List<IEvent>()
            {
                new Event(Guid.NewGuid(), "ДР", "День рождения Виталия", DateTime.Parse("22.04.2023"), DateTime.Parse("23.04.2023"), Guid.NewGuid(), Guid.NewGuid()),
                new Event(Guid.NewGuid(), "Собеседование", "Собеседование Николая", DateTime.Parse("17.04.2023 15:00"), DateTime.Parse("17.04.2023 16:00"), Guid.NewGuid(), Guid.NewGuid())
            };
        }

        public async Task<IEnumerable<IEvent>> Get()
        {
            return await Task.FromResult(_events);
        }

        public async Task Add(IEvent eEvent)
        {
            _events.Add(eEvent);
        }

        public async Task Update(IEvent eEvent)
        {
            if (_events.Exists(e => e.Id == eEvent.Id))
            {
                var eventToUpdate = _events.FirstOrDefault(e => e.Id == eEvent.Id);
                eventToUpdate.StartDateTime = eEvent.StartDateTime;
                eventToUpdate.EndDateTime = eEvent.EndDateTime;
                eventToUpdate.Description = eEvent.Description;
                eventToUpdate.Name = eEvent.Name;
                eventToUpdate.ImageId = eEvent.ImageId;
                eventToUpdate.SpaceId = eEvent.SpaceId;
            }
            else
            {
                 _events.Add(eEvent);
            }
        }

        public async Task Delete(Guid idEvent)
        {
            if (_events.Exists(e => e.Id == idEvent))
            {
                var eventToDelete = _events.FirstOrDefault(e => e.Id == idEvent);
                _events.Remove(eventToDelete);
            }
        }
    }
}
