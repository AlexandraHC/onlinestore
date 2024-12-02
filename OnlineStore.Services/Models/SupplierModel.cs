using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Services.Models
{
    public class SupplierModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
