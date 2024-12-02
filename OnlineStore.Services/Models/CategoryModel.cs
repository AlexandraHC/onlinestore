using System.ComponentModel.DataAnnotations;

namespace OnlineStore.Services.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
