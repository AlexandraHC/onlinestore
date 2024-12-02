using System.ComponentModel.DataAnnotations;
using OnlineStore.Services.Attributes;

namespace OnlineStore.Services.Models
{
    public class CreateUserModel
    {
        [Required]
        [StringLength(255, ErrorMessage = "Must be at least 5 characters", MinimumLength = 5)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Must be at least 5 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Must be at least 5 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [ComparePasswords("Password", ErrorMessage = "The passwords do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
