using FluentValidation;

namespace Book_Store.Application.DTOs.Publisher.Validators
{
    public class IPublisherDtoValidator : AbstractValidator<IPublisherDto>
    {
        public IPublisherDtoValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("عنوان انتشارات نمی تواند خالی باشد.")
                .NotNull().MaximumLength(100).WithMessage("عنوان نمی تواند بیشتر از 100 کاراکتر باشد.");
        }
    }
}
