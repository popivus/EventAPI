using EventAPI.Features.Ticket.AddTicket;
using EventAPI.Services.Interfaces;
using MediatR;
using SC.Internship.Common.ScResult;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EventAPI.Features.Ticket.CheckUserTicket
{
    public class CheckUserTicketHandler : IRequestHandler<CheckUserTicketQuery, ScResult>
    {
        private readonly IEventDatabaseService _eventDatabaseService;

        public CheckUserTicketHandler(IEventDatabaseService eventDatabaseService)
        {
            _eventDatabaseService = eventDatabaseService;
        }

        public async Task<ScResult> Handle(CheckUserTicketQuery request, CancellationToken cancellationToken)
        {
            var events = await _eventDatabaseService.Get();
            var currentEvent = events.FirstOrDefault(e => e.Id == request.EventId);

            if (currentEvent == null)
            {
                ScError scError = new ScError();
                scError.Message = "Такого мероприятия не существует";
                return new ScResult(scError);
            }

            if (currentEvent.Tickets.Any(t => t.UserId == request.UserId))
                return new ScResult();
            else
            {

                ScError scError = new ScError();
                scError.Message = "У данного пользователя нет билета на это мероприятие";
                return new ScResult(scError);
            }
        }
    }
}
