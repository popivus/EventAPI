using EventAPI.Models.Interfaces;
using FluentValidation.Results;
using MediatR;

namespace EventAPI.Commands
{
    public record DeleteEventCommand(Guid IdEvent) : IRequest<bool>;
}
