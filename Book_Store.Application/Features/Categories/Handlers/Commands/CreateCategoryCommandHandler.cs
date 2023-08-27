using AutoMapper;
using Book_Store.Application.DTOs.Category.Validators;
using Book_Store.Application.Features.Categories.Requests.Commands;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Domain.Entites;
using MediatR;
using Book_Store.Application.Responses;

namespace Book_Store.Application.Features.Categories.Handlers.Commands
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, BaseCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation

            var validator = new CreateCategoryDtoValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request.CreateCategoryDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            #endregion

            var category = _mapper.Map<Category>(request.CreateCategoryDto);
            category = await _categoryRepository.Add(category);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = category.Id;

            return response;
        }
    }
}
