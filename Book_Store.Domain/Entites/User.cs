namespace Book_Store.Domain.Entites
{
    public class User
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public byte[] Avatar { get; set; }


        public ICollection<Comment> Comments { get; set; }
    }
}
