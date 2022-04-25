namespace StoreWebAPI_Assignment.Models.Order
{
    public class Order
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; } = null!;

        public string Address { get; set; } = null!;

        public DateTime OrderDate { get; set; }

        public string OrderStatus { get; set; } = null!;
    }
}
