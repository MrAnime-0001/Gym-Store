using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Gym_Store.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Product Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [DisplayName("Product Type")]
        public string Type { get; set; }

        [Required]
        [Range(0.01, 10000, ErrorMessage = "Please enter a valid price between 0.01 and 10000")]
        [DisplayName("Price (NZD)")]
        public decimal Price { get; set; }

        [Required]
        public string Quantity { get; set; }

        [Required(ErrorMessage = "An image URL is required")]
        [DisplayName("Image URL")]
        [RegularExpression(@"^/Gym_Store/Images/.+\.(jpg|jpeg|png|gif)$",
            ErrorMessage = "URL must start with '/Gym_Store/Images/' and end in .jpg/.png/.gif")]
        public string ImageUrl { get; set; }
    }
}
