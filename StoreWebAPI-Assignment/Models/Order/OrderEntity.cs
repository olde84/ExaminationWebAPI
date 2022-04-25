using System.ComponentModel.DataAnnotations;

namespace StoreWebAPI_Assignment.Models.Order
{
    public class OrderEntity
    {
        public OrderEntity()
        {

        }

        public OrderEntity(int id, int customerId, string customerName, string address, DateTime orderDate, string orderStatus, ICollection<OrderRowEntity> orderRows)
        {
            Id = id;
            CustomerId = customerId;
            CustomerName = customerName;
            Address = address;
            OrderDate = orderDate;
            OrderStatus = orderStatus;
            OrderRows = orderRows;
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        public string CustomerName { get; set; } = null!;

        [Required]
        public string Address { get; set; } = null!;

        [Required]
        public DateTime OrderDate { get; set; }

        [Required]
        public string OrderStatus { get; set; } = null!;

        public virtual ICollection<OrderRowEntity> OrderRows { get; set; } = null!;

    }
}
