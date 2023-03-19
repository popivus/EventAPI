using EventAPI.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SC.Internship.Common.Exceptions;
using SC.Internship.Common.ScResult;

namespace EventAPI.Features.Event.AddEvent
{
    public class AddEventHandler : IRequestHandler<AddEventCommand, ScResult>
    {
        private readonly IEventDatabaseService _eventDatabaseService;
        private readonly IValidator<IEvent> _validator;

        public AddEventHandler(IEventDatabaseService eventDatabaseService, IValidator<IEvent> validator)
        {
            _eventDatabaseService = eventDatabaseService;
            _validator = validator;
        }

        public async Task<ScResult> Handle(AddEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = request.Event;
            
            var result = await _validator.ValidateAsync(newEvent, cancellationToken);
            ScResult scResult = new ScResult();
            if (result.IsValid)
            {
                await _eventDatabaseService.Add(newEvent);
            }
            else
            {
                ScError scError = new ScError();
                scError.ModelState = new();
                scError.Message = "Неверный формат данных";
                foreach (var error in result.Errors)
                    scError.ModelState.Add(error.PropertyName, new List<string> { error.ErrorMessage });
                scResult.Error = scError;
            }
            return scResult;
        }
    }
}
