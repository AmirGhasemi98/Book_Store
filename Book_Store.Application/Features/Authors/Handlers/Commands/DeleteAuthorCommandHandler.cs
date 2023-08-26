using AutoMapper;
using Book_Store.Application.Features.Authors.Requests.Commands;
using Book_Store.Application.Contracts.Persistence;
using MediatR;
using Book_Store.Application.Responses;

namespace Book_Store.Application.Features.Authors.Handlers.Commands
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, BaseCommandResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var author = await _authorRepository.Get(request.Id);

            if (author is null)
            {
                response.Success = false;
                response.Message = "نویسنده یافت نشد.";
                response.Errors.Add("نویسنده یافت نشد.");

                return response;
            }


            await _authorRepository.Delete(author);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = author.Id;

            return response;
        }
    }
}
