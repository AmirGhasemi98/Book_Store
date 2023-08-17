using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.Author.Validators;
using Book_Store.Application.Features.Authors.Requests.Commands;
using MediatR;

namespace Book_Store.Application.Features.Authors.Handlers.Commands
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            #region Validation

            var validator = new UpdateAuthorDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateAuthorDto);

            if (!validationResult.IsValid)
                throw new Exception();

            #endregion

            var author = await _authorRepository.Get(request.UpdateAuthorDto.Id);
            _mapper.Map(request.UpdateAuthorDto, author);
            await _authorRepository.Update(author);
            return Unit.Value;
        }
    }
}
