using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Services.Models
{
    public class PaymentMethodModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
