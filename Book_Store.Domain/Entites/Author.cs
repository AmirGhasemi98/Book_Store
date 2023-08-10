using Book_Store.Domain.Common;

namespace Book_Store.Domain.Entites
{
    public class Author : BaseDomainEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}
