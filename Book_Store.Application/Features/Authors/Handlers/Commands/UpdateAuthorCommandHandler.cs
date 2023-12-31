﻿using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.DTOs.Author.Validators;
using Book_Store.Application.Features.Authors.Requests.Commands;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Authors.Handlers.Commands
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, BaseCommandResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public UpdateAuthorCommandHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            #region Validation

            var validator = new UpdateAuthorDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateAuthorDto);

            if (!validationResult.IsValid)
            {
                response.Success = false;
                response.Message = "مشکلی پیش آمده است.";
                response.Errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();

                return response;
            }

            #endregion

            var author = await _authorRepository.Get(request.UpdateAuthorDto.Id);

            if (author is null)
            {
                response.Success = false;
                response.Message = "نویسنده یافت نشد.";
                response.Errors.Add("نویسنده یافت نشد.");

                return response;
            }

            _mapper.Map(request.UpdateAuthorDto, author);
            await _authorRepository.Update(author);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = author.Id;

            return response;
        }
    }
}
