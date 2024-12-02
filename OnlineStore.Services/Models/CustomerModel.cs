namespace OnlineStore.Services.Models
{
    public class CustomerModel
    {
        public int CustomerId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; } = null!;

        public string PhoneNumber { get; set; } = null!;

        public int UserId { get; set; }

        public virtual ICollection<AddressModel> Addresses { get; set; } = new List<AddressModel>();
    }
}
