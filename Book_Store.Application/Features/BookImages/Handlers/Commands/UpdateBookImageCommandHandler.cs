using Book_Store.Application.Contracts.Persistence;
using Book_Store.Application.Features.BookImages.Requests.Commands;
using Book_Store.Application.Responses;
using MediatR;

namespace Book_Store.Application.Features.BookImages.Handlers.Commands
{
    public class UpdateBookImageCommandHandler : IRequestHandler<UpdateBookImageCommand, BaseCommandResponse>
    {
        private readonly IBookImageRepository _bookImageRepository;
        private readonly IMediator _mediator;

        public UpdateBookImageCommandHandler(IBookImageRepository bookImageRepository, IMediator mediator)
        {
            _bookImageRepository = bookImageRepository;
            _mediator = mediator;
        }

        public async Task<BaseCommandResponse> Handle(UpdateBookImageCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();

            var bookImage = await _bookImageRepository.GetBy(request.UpdateBookImage.BookId);

            if (bookImage is null)
            {
                var bookImageResponse = await _mediator.Send(new CreateBookImageCommand
                {
                    CreateBookImageDto = new DTOs.BookImage.CreateBookImageDto
                    { BookId = request.UpdateBookImage.BookId, Image = request.UpdateBookImage.Image }
                });
            }
            else
            {
                using (MemoryStream stream = new MemoryStream())
                {
                    request.UpdateBookImage.Image.CopyTo(stream);
                    byte[] bytes = stream.GetBuffer();

                    bookImage.File = bytes;
                }

                bookImage.ContentType = request.UpdateBookImage.Image.ContentType;
                bookImage.FileName = request.UpdateBookImage.Image.FileName;

                await _bookImageRepository.Update(bookImage);

            }

            response.Success = true;
            response.Message = "عملیات با موفقیت انجام شد.";
            response.Id = bookImage.Id;

            return response;
        }
    }
}
