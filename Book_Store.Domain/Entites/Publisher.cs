using Book_Store.Domain.Common;

namespace Book_Store.Domain.Entites
{
    public class Publisher : BaseDomainEntity
    {
        public string Title { get; set; }

        #region Relations

        public ICollection<Book> Books { get; set; }

        #endregion
    }
}
