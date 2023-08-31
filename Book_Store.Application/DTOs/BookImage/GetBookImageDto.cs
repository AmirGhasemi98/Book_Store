namespace Book_Store.Application.DTOs.BookImage
{
    public class GetBookImageDto
    {
        public string ContentType { get; set; }

        public string FileName { get; set; }

        public byte[] File { get; set; }
    }
}
