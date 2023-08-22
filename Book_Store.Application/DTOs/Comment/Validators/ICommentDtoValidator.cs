using FluentValidation;

namespace Book_Store.Application.DTOs.Comment.Validators
{
    public class ICommentDtoValidator : AbstractValidator<ICommentDto>
    {
        public ICommentDtoValidator()
        {
            RuleFor(c => c.Text).NotEmpty().NotNull().WithMessage("متن نظر را وارد نمایید.");

            RuleFor(c => c.Rating).GreaterThanOrEqualTo(0);
        }
    }
}
