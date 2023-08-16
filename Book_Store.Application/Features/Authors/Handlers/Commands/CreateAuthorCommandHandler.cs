using AutoMapper;
using Book_Store.Application.DTOs.Author.Validators;
using Book_Store.Application.Features.Authors.Requests.Commands;
using Book_Store.Application.Persistence.Contracts;
using Book_Store.Application.Responses;
using Book_Store.Domain.Entites;
using MediatR;

namespace Book_Store.Application.Features.Authors.Handlers.Commands
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, BaseCommandResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation

            var validator = new CreateAuthorDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateAuthorDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            }

            #endregion

            var author = _mapper.Map<Author>(request.CreateAuthorDto);
            author = await _authorRepository.Add(author);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = author.Id;

            return response;
        }
    }
}
