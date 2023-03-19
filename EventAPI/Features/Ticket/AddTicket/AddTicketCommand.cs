using FluentValidation.Results;
using MediatR;
using SC.Internship.Common.ScResult;

namespace EventAPI.Features.Ticket.AddTicket
{
    public record AddTicketCommand(ITicket Ticket, Guid EventID) : IRequest<ScResult>;
}
