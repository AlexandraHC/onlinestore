using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Services.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        public string ProductName { get; set; } = null!;

        public string? ProductDescription { get; set; }

        [Required]
        public decimal PriceWithoutVat { get; set; }

        [Required]
        public decimal PriceWithVat { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public bool IsActive { get; set; }
    }
}
