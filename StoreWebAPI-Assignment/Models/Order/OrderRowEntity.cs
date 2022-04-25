using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreWebAPI_Assignment.Models.Order
{
    public class OrderRowEntity
    {
        public OrderRowEntity()
        {

        }

        public OrderRowEntity(int orderId, int articleNumber, string productName, int quantity, decimal productPrice, OrderEntity order)
        {
            OrderId = orderId;
            ArticleNumber = articleNumber;
            ProductName = productName;
            Quantity = quantity;
            ProductPrice = productPrice;
            Order = order;
        }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int ArticleNumber { get; set; }

        [Required]
        public string ProductName { get; set; } = null!;

        [Required]
        public int Quantity { get; set; }

        [Required]
        [Column(TypeName = "money")]
        public decimal ProductPrice { get; set; }

        public OrderEntity Order { get; set; } = null!;
    }
}
