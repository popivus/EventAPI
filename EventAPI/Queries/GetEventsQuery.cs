using EventAPI.Models.Interfaces;
using MediatR;

namespace EventAPI.Queries
{
    public record GetEventsQuery : IRequest<IEnumerable<IEvent>>;
}

