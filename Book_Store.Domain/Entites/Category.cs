using Book_Store.Domain.Common;

namespace Book_Store.Domain.Entites
{
    public class Category : BaseDomainEntity
    {
        public string Title { get; set; }

        public int? ParentId { get; set; }

        public Category Parent { get; set; }
    }
}
