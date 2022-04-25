namespace StoreWebAPI_Assignment.Models.Product
{
    public class ProductModel
    {
        public int ArticleNumber { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public string CategoryName { get; set; } = null!;
    }
}
