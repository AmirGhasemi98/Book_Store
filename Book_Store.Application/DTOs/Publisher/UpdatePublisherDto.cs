using Book_Store.Application.DTOs.Common;

namespace Book_Store.Application.DTOs.Publisher
{
    public class UpdatePublisherDto : BaseDto, IPublisherDto
    {
        public string Title { get; set; }
    }
}
