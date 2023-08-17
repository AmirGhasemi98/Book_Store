using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.Category.Validators;
using Book_Store.Application.Features.Categories.Requests.Commands;
using MediatR;

namespace Book_Store.Application.Features.Categories.Handlers.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Unit>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            #region Validation

            var validator = new UpdateCategoryDtoValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateCategoryDto);

            if (!validationResult.IsValid)
                throw new Exception();

            #endregion

            var category = await _categoryRepository.Get(request.UpdateCategoryDto.Id);
            _mapper.Map(request.UpdateCategoryDto, category);
            await _categoryRepository.Update(category);
            return Unit.Value;

        }
    }
}
