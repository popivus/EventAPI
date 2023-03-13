using EventAPI.Commands;
using EventAPI.Models.Interfaces;
using EventAPI.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace EventAPI.Handlers
{
    public class AddEventHandler : IRequestHandler<AddEventCommand, IEnumerable<ValidationFailure>>
    {
        private readonly IEventDatabaseService _eventDatabaseService;
        private readonly IValidator<IEvent> _validator;

        public AddEventHandler(IEventDatabaseService eventDatabaseService, IValidator<IEvent> validator)
        {
            _eventDatabaseService = eventDatabaseService;
            _validator = validator;
        }

        public async Task<IEnumerable<ValidationFailure>> Handle(AddEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = request.Event;
            var result = await _validator.ValidateAsync(newEvent, cancellationToken);
            if (result.IsValid)
            {
                await _eventDatabaseService.Add(newEvent);
            }
            return result.Errors;
        }
    }
}
