using Book_Store.Domain.Common;

namespace Book_Store.Domain.Entites
{
    public class Book : BaseDomainEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public double? Price { get; set; }

        public int Inventory { get; set; }

        #region Relations

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public ICollection<BookImage> BookImages { get; set; }

        public ICollection<BookMapAuthor> bookMapAuthors { get; set; }

        public ICollection<BookMapTranslator> bookMapTranslators { get; set; }

        #endregion

    }
}
