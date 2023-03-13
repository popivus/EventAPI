using EventAPI.Models.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace EventAPI.Commands
{
    public record UpdateEventCommand(IEvent Event) : IRequest<IEnumerable<ValidationFailure>>;
}
