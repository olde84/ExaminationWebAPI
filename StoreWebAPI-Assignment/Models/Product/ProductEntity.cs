using StoreWebAPI_Assignment.Models.Category;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StoreWebAPI_Assignment.Models.Product
{
    public class ProductEntity
    {
        public ProductEntity()
        {

        }
        public ProductEntity(int articleNr, string name, string description, decimal price, int categoryId, CategoryEntity category)
        {
            ArticleNr = articleNr;
            Name = name;
            Description = description;
            Price = price;
            CategoryId = categoryId;
            Category = category;
        }

        [Key]
        public int ArticleNr { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [Required]
        public int CategoryId { get; set; }
        public virtual CategoryEntity Category { get; set; } = null!;
    }
}
