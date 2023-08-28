using AutoMapper;
using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.Features.BookImages.Requests.Commands;
using Book_Store.Application.Responses;
using Book_Store.Domain.Entites;
using MediatR;

namespace Book_Store.Application.Features.BookImages.Handlers.Commands
{
    public class CreateBookImageCommandHandler : IRequestHandler<CreateBookImageCommand, BaseCommandResponse>
    {
        private readonly IBookImageRepository _bookImageRepository;
        private readonly IMapper _mapper;

        public CreateBookImageCommandHandler(IBookImageRepository bookImageRepository, IMapper mapper)
        {
            _bookImageRepository = bookImageRepository;
            _mapper = mapper;
        }

        public async Task<BaseCommandResponse> Handle(CreateBookImageCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var bookImage = new BookImage();

            using (MemoryStream stream = new MemoryStream())
            {
                request.CreateBookImageDto.Image.CopyTo(stream);
                byte[] bytes = stream.GetBuffer();

                bookImage.File = bytes;
            }

            bookImage.BookId = request.CreateBookImageDto.BookId;

            bookImage = await _bookImageRepository.Add(bookImage);

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = bookImage.Id;

            return response;
        }
    }
}
