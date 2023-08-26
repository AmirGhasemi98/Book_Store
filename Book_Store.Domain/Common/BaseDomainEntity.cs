namespace Book_Store.Domain.Common
{
    public class BaseDomainEntity
    {
        public int Id { get; set; }

        public DateTime DateCreated { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public string? ModifiedBy { get; set; }
    }
}
