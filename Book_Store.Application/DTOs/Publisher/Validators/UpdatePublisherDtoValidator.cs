using FluentValidation;

namespace Book_Store.Application.DTOs.Publisher.Validators
{
    public class UpdatePublisherDtoValidator : AbstractValidator<UpdatePublisherDto>
    {
        public UpdatePublisherDtoValidator()
        {
            Include(new IPublisherDtoValidator());

            RuleFor(c => c.Id).NotEmpty().NotNull().GreaterThan(0);
        }
    }
}
