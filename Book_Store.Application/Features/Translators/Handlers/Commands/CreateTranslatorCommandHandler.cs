using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.Author.Validators;
using Book_Store.Application.DTOs.Translator.Validators;
using Book_Store.Application.Features.Translators.Requests.Commands;
using Book_Store.Application.Responses;
using Book_Store.Domain.Entites;
using MediatR;

namespace Book_Store.Application.Features.Translators.Handlers.Commands
{
    public class CreateTranslatorCommandHandler : IRequestHandler<CreateTranslatorCommand, BaseCommandResponse>
    {
        private readonly ITranslatorRepository _translatorRepository;
        private readonly IMapper _mapper;

        public CreateTranslatorCommandHandler(ITranslatorRepository translatorRepository, IMapper mapper)
        {
            _translatorRepository = translatorRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateTranslatorCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation

            var validator = new CreateTranslatorDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateTranslatorDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            var translator = _mapper.Map<Translator>(request.CreateTranslatorDto);
            translator = await _translatorRepository.Add(translator);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = translator.Id;

            return response;

            #endregion
        }
    }
}
