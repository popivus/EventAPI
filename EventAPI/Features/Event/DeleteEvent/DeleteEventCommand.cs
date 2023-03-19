using EventAPI.Models.Interfaces;
using FluentValidation.Results;
using MediatR;
using SC.Internship.Common.ScResult;

namespace EventAPI.Features.Event.DeleteEvent
{
    public record DeleteEventCommand(Guid IdEvent) : IRequest<ScResult>;
}
