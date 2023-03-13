using EventAPI.Models.Interfaces;
using EventAPI.Services.Interfaces;
using FluentValidation;

namespace EventAPI.Validators
{
    public class EventValidator : AbstractValidator<IEvent>
    {
        private readonly IImageService _imageService;
        private readonly ISpaceService _spaceService;

        public EventValidator(ISpaceService spaceService, IImageService imageService)
        {
            _spaceService = spaceService;
            _imageService = imageService;

            RuleFor(e => e.Id).NotNull().WithMessage("Заполните поле Id");
            RuleFor(e => e.Name).NotNull().WithMessage("Заполните поле Name"); 
            RuleFor(e => e.ImageId).Must(_imageService.ImageExists).WithMessage("Не существует такой картинки"); 
            RuleFor(e => e.SpaceId).Must(_spaceService.SpaceExists).WithMessage("Не существует такого пространства"); 
            RuleFor(e => e.StartDateTime).LessThan(ev => ev.EndDateTime).WithMessage("Дата начала должна быть раньше даты окончания");
        }
    }
}
