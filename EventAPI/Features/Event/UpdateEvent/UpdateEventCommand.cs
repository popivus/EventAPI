using EventAPI.Features.Event;
using FluentValidation.Results;
using MediatR;
using SC.Internship.Common.ScResult;

namespace EventAPI.Features.Event.UpdateEvent
{
    public record UpdateEventCommand(IEvent Event) : IRequest<ScResult>;
}
