using FluentValidation;

namespace Book_Store.Application.DTOs.Publisher.Validators
{
    public class CreatePublisherDtoValidator : AbstractValidator<CreatePublisherDto>
    {
        public CreatePublisherDtoValidator()
        {
            Include(new IPublisherDtoValidator());
        }
    }
}
