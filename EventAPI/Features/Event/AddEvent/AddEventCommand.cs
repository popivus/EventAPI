using FluentValidation.Results;
using MediatR;
using SC.Internship.Common.ScResult;

namespace EventAPI.Features.Event.AddEvent
{
    public record AddEventCommand(IEvent Event) : IRequest<ScResult>;
}
