using Book_Store.Domain.Common;

namespace Book_Store.Domain.Entites
{
    public class Book : BaseDomainEntity
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public double? Price { get; set; }

        public int Inventory { get; set; }

        public byte Image { get; set; }

        #region Relations

        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public int AuthorId { get; set; }

        public Author Author { get; set; }

        public int PublisherId { get; set; }

        public Publisher Publisher { get; set; }



        #endregion

    }
}
