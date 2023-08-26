using AutoMapper;
using Book_Store.Application.Features.Categories.Requests.Commands;
using Book_Store.Application.Contracts.Persistence;
using MediatR;
using Book_Store.Application.Responses;

namespace Book_Store.Application.Features.Categories.Handlers.Commands
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, BaseCommandResponse>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var catrgory = await _categoryRepository.Get(request.Id);


            if (catrgory is null)
            {
                response.Success = false;
                response.Message = "دسته بندی یافت نشد.";
                response.Errors.Add("دسته بندی یافت نشد.");

                return response;
            }

            await _categoryRepository.Delete(catrgory);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = catrgory.Id;

            return response;
        }
    }
}
