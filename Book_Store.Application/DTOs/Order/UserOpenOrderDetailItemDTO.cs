namespace Book_Store.Application.DTOs.Order
{
    public class UserOpenOrderDetailItemDTO
    {
        public int DetailId { get; set; }

        public int BookId { get; set; }

        public string BookTitle { get; set; }

        public int Count { get; set; }

        public int BookPrice { get; set; }


    }
}
