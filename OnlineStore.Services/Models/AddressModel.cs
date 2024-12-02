namespace OnlineStore.Services.Models
{
    public class AddressModel
    {
        public int AddressId { get; set; }

        public int CustomerId { get; set; }

        public string City { get; set; } = null!;

        public string Street { get; set; } = null!;

        public string StreetNumber { get; set; } = null!;

        public string PostalCode { get; set; } = null!;

        public string Country { get; set; } = null!;
    }
}
