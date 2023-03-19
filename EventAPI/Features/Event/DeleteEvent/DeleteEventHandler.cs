using EventAPI.Services.Interfaces;
using FluentValidation;
using MediatR;
using SC.Internship.Common.ScResult;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventAPI.Features.Event.DeleteEvent
{
    public class DeleteEventHandler : IRequestHandler<DeleteEventCommand, ScResult>
    {
        private readonly IEventDatabaseService _eventDatabaseService;

        public DeleteEventHandler(IEventDatabaseService eventDatabaseService)
        {
            _eventDatabaseService = eventDatabaseService;
        }
        public async Task<ScResult> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            var events = _eventDatabaseService.Get().Result;
            var eventToDelete = events.FirstOrDefault(e => e.Id == request.IdEvent);
            if (eventToDelete == null)
            {
                ScError scError = new ScError();
                scError.Message = "Такого мероприятия не существует";
                return new ScResult(scError);
            }

            await _eventDatabaseService.Delete(eventToDelete.Id);
            return new ScResult();
        }
    }
}
