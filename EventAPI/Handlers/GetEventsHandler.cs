using EventAPI.Models.Interfaces;
using EventAPI.Queries;
using EventAPI.Services.Interfaces;
using MediatR;

namespace EventAPI.Handlers
{
    public class GetEventsHandler : IRequestHandler<GetEventsQuery, IEnumerable<IEvent>>
    {
        private readonly IEventDatabaseService _eventDatabaseService;
        
        public GetEventsHandler(IEventDatabaseService eventDatabaseService)
        {
            _eventDatabaseService = eventDatabaseService;
        }

        public async Task<IEnumerable<IEvent>> Handle(GetEventsQuery request, CancellationToken cancellationToken)
        {
            return await _eventDatabaseService.Get();
        }
    }
}
