using EventAPI.Commands;
using EventAPI.Models.Interfaces;
using EventAPI.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace EventAPI.Handlers
{
    public class DeleteEventHandler : IRequestHandler<DeleteEventCommand, bool>
    {
        private readonly IEventDatabaseService _eventDatabaseService;

        public DeleteEventHandler(IEventDatabaseService eventDatabaseService, IValidator<IEvent> validator)
        {
            _eventDatabaseService = eventDatabaseService;
        }
        public async Task<bool> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var events = _eventDatabaseService.Get().Result;
            var eventToDelete = events.FirstOrDefault(e => e.Id == request.IdEvent);
            if (eventToDelete == null)
                return false;

            await _eventDatabaseService.Delete(eventToDelete.Id);
            return true;
            
        }
    }
}
