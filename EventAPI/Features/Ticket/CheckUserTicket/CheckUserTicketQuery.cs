using EventAPI.Features.Event;
using MediatR;
using SC.Internship.Common.ScResult;

namespace EventAPI.Features.Ticket.CheckUserTicket
{
    public record CheckUserTicketQuery(Guid UserId, Guid EventId) : IRequest<ScResult>;
}
