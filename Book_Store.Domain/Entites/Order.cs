using Book_Store.Domain.Common;
using Book_Store.Domain.Identity;

namespace Book_Store.Domain.Entites
{
    public class Order : BaseDomainEntity
    {
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public DateTime? PaymentDate { get; set; }

        public bool IsPaid { get; set; }

        public string TracingCode { get; set; }

        public string Description { get; set; }

        #region Relations

        public ICollection<OrderDetail> OrderDetails { get; set; }

        #endregion
    }
}
