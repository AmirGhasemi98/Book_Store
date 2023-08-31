﻿using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.Translators.Requests.Commands
{
    public class DeleteTranslatorCommand : IRequest<BaseCommandResponse>
    {
        public int Id { get; set; }
    }
}
