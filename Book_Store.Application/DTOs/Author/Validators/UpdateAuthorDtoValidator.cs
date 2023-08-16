using FluentValidation;

namespace Book_Store.Application.DTOs.Author.Validators
{
    public class UpdateAuthorDtoValidator : AbstractValidator<UpdateAuthorDto>
    {
        public UpdateAuthorDtoValidator()
        {
            Include(new IAuthorDtoValidator());
        }
    }
}
