using Book_Store.Domain.Common;

namespace Book_Store.Domain.Entites
{
    public class Category : BaseDomainEntity
    {
        public string Title { get; set; }

        public int? ParentId { get; set; }

        public Category Parent { get; set; }

        #region Relations

        public ICollection<Category> Children { get; set; }

        public ICollection<Book> Books { get; set; }

        #endregion


    }
}
