namespace StoreWebAPI_Assignment.Models.Product
{
    public class ProductRequest
    {
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
