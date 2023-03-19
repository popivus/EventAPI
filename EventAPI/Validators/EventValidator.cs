using EventAPI.Features.Event;
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

            RuleFor(e => e.Id).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Заполните поле Id");
            RuleFor(e => e.Name).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Заполните поле Name");
            RuleFor(e => e.ImageId).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Заполните поле ImageId").Must(_imageService.ImageExists).WithMessage("Не существует такой картинки"); 
            RuleFor(e => e.SpaceId).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Заполните поле SpaceId").Must(_spaceService.SpaceExists).WithMessage("Не существует такого пространства"); 
            RuleFor(e => e.StartDateTime).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Заполните поле StartDateTime").LessThan(ev => ev.EndDateTime).WithMessage("Дата начала должна быть раньше даты окончания");
            RuleFor(e => e.EndDateTime).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Заполните поле EndDateTime");
            RuleFor(e => e.Availability).Cascade(CascadeMode.Stop).NotEmpty().WithMessage("Заполните поле Availability");
        }
    }
}
