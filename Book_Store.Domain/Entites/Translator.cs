using Book_Store.Domain.Common;

namespace Book_Store.Domain.Entites
{
    public class Translator : BaseDomainEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<BookMapTranslator> bookMapTranslators { get; set; }
    }
}
