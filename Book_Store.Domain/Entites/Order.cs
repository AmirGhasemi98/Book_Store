using Book_Store.Domain.Common;

namespace Book_Store.Domain.Entites
{
    public class Order : BaseDomainEntity
    {
        public DateTime Date { get; set; }
    }
}
