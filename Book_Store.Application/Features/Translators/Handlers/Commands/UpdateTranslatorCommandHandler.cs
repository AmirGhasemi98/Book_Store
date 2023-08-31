using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.Translator.Validators;
using Book_Store.Application.Features.Translators.Requests.Commands;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Translators.Handlers.Commands
{
    public class UpdateTranslatorCommandHandler : IRequestHandler<UpdateTranslatorCommand, BaseCommandResponse>
    {
        private readonly ITranslatorRepository _translatorRepository;
        private readonly IMapper _mapper;

        public UpdateTranslatorCommandHandler(ITranslatorRepository translatorRepository, IMapper mapper)
        {
            _translatorRepository = translatorRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateTranslatorCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation

            var validator = new UpdateTranslatorDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateTranslatorDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            #endregion

            var translator = await _translatorRepository.Get(request.UpdateTranslatorDto.Id);

            if (translator is null)
            {
                response.Success = false;
                response.Message = "مترجم یافت نشد.";
                response.Errors.Add("مترجم یافت نشد.");

                return response;
            }

            _mapper.Map(request.UpdateTranslatorDto, translator);
            await _translatorRepository.Update(translator);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = translator.Id;

            return response;
        }
    }
}
