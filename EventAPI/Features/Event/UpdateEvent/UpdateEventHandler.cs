using EventAPI.Services.Interfaces;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using SC.Internship.Common.ScResult;

namespace EventAPI.Features.Event.UpdateEvent
{
    public class UpdateEventHandler : IRequestHandler<UpdateEventCommand, ScResult>
    {
        private readonly IEventDatabaseService _eventDatabaseService;
        private readonly IValidator<IEvent> _validator;

        public UpdateEventHandler(IEventDatabaseService eventDatabaseService, IValidator<IEvent> validator)
        {
            _eventDatabaseService = eventDatabaseService;
            _validator = validator;
        }

        public async Task<ScResult> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
        {
            var newEvent = request.Event;

            var result = await _validator.ValidateAsync(newEvent, cancellationToken);
            ScResult scResult = new ScResult();
            if (result.IsValid)
            {
                await _eventDatabaseService.Update(newEvent);
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
