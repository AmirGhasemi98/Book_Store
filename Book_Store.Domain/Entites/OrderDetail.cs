using Book_Store.Domain.Common;

namespace Book_Store.Domain.Entites
{
    public class OrderDetail : BaseDomainEntity
    {
        public int OrderId { get; set; }

        public int BookId { get; set; }

        public int Count { get; set; }

        public int? BookPrice { get; set; }

        #region Relations

        public Order Order { get; set; }

        public Book Book { get; set; }

        #endregion
    }
}
