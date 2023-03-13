using EventAPI.Commands;
using EventAPI.Models.Interfaces;
using EventAPI.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace EventAPI.Handlers
{
    public class UpdateEventHandler : IRequestHandler<UpdateEventCommand, IEnumerable<ValidationFailure>>
    {
        private readonly IEventDatabaseService _eventDatabaseService;
        private readonly IValidator<IEvent> _validator;

        public UpdateEventHandler(IEventDatabaseService eventDatabaseService, IValidator<IEvent> validator)
        {
            _eventDatabaseService = eventDatabaseService;
            _validator = validator;
        }

        public async Task<IEnumerable<ValidationFailure>> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = request.Event;
            var result = await _validator.ValidateAsync(newEvent, cancellationToken);
            if (result.IsValid)
            {
                await _eventDatabaseService.Update(newEvent);
            }
            return result.Errors;
        }
    }
}
