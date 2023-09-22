namespace Book_Store.Application.DTOs.Order
{
    public class UserOpenOrderDTO
    {
        public int UserId { get; set; }

        public string Description { get; set; }

        public List<UserOpenOrderDetailItemDTO> Details { get; set; }

        public int GetTotalPrice()
        {
            return Details.Sum(s => s.BookPrice * s.Count);
        }


    }
}
