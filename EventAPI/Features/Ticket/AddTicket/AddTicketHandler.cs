using EventAPI.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SC.Internship.Common.ScResult;

namespace EventAPI.Features.Ticket.AddTicket
{
    public class AddTicketHandler : IRequestHandler<AddTicketCommand, ScResult>
    {
        private readonly IEventDatabaseService _eventDatabaseService;

        public AddTicketHandler(IEventDatabaseService eventDatabaseService)
        {
            _eventDatabaseService = eventDatabaseService;
        }

        public async Task<ScResult> Handle(AddTicketCommand request, CancellationToken cancellationToken)
        {
            var events = await _eventDatabaseService.Get();
            var currentEvent = events.FirstOrDefault(e => e.Id == request.EventID);
            if (currentEvent == null)
            {
                ScError scError = new ScError();
                scError.Message = "Мероприятия с таким Id не существует";
                return new ScResult(scError);
            }

            if (!currentEvent.Availability)
            {
                ScError scError = new ScError();
                scError.Message = "На мероприятии кончились свободные места";
                return new ScResult(scError);
            }

            await _eventDatabaseService.AddTicket(request.Ticket, request.EventID);
            return new ScResult();
            
        }
    }
}
