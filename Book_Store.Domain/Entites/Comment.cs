using Book_Store.Domain.Common;

namespace Book_Store.Domain.Entites
{
    public class Comment : BaseDomainEntity
    {
        public string Text { get; set; }

        public int Rating { get; set; }

       // public string UserId { get; set; }

        

        #region Relations

        public int BookId { get; set; }

        public Book Book { get; set; }

        #endregion
    }
}
