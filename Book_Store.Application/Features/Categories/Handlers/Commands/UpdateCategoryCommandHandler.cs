using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.Category.Validators;
using Book_Store.Application.Features.Categories.Requests.Commands;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Categories.Handlers.Commands
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, BaseCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation

            var validator = new UpdateCategoryDtoValidator(_categoryRepository);
            var validationResult = await validator.ValidateAsync(request.UpdateCategoryDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            #endregion

            var category = await _categoryRepository.Get(request.UpdateCategoryDto.Id);

            if (category is null)
            {
                response.Success = false;
                response.Message = "دسته بندی یافت نشد.";
                response.Errors.Add("دسته بندی یافت نشد.");

                return response;
            }

            _mapper.Map(request.UpdateCategoryDto, category);
            await _categoryRepository.Update(category);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = category.Id;

            return response;

        }
    }
}
