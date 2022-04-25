using StoreWebAPI_Assignment.Models.Product;
using System.ComponentModel.DataAnnotations;

namespace StoreWebAPI_Assignment.Models.Category
{
    public class CategoryEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<ProductEntity> Products { get; set; } = null!;
    }
}
