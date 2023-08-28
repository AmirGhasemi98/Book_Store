using Book_Store.Domain.Common;

namespace Book_Store.Domain.Entites
{
    public class BookImage : BaseDomainEntity
    {
        public int BookId { get; set; }

        public Book Book { get; set; }

        public byte[] File { get; set; }
    }
}
