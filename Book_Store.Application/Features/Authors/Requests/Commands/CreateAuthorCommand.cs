﻿using Book_Store.Application.DTOs.Author;
using MediatR;

namespace Book_Store.Application.Features.Authors.Requests.Commands
{
    public class CreateAuthorCommand : IRequest<int>
    {
        public CreateAuthorDto AuthorDto { get; set; }
    }
}
