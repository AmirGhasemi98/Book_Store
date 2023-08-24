using Book_Store.Domain.Common;
using Book_Store.Domain.Identity;

namespace Book_Store.Domain.Entites
{
    public class Comment : BaseDomainEntity
    {
        public string Text { get; set; }

        public int Rating { get; set; }



        #region Relations

        public int UserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public int BookId { get; set; }

        public Book Book { get; set; }

        #endregion
    }
}
