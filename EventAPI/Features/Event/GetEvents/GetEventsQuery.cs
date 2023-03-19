using EventAPI.Features.Event;
using MediatR;

namespace EventAPI.Features.Event.GetEvents
{
    public record GetEventsQuery : IRequest<IEnumerable<IEvent>>;
}

