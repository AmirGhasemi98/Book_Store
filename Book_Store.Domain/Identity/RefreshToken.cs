namespace Book_Store.Domain.Identity
{
    public class RefreshToken
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string JwtTokenId { get; set; }

        public string Refresh_Token { get; set; }

        public bool IsValid { get; set; }

        public DateTime ExpireAt { get; set; }
    }
}
