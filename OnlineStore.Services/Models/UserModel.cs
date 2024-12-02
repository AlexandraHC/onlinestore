namespace OnlineStore.Services.Models
{
    public class UserModel
    {
        public int Id { get; set; }

        public string UserName { get; set; } = null!;

        public string Email { get; set; } = null!;

        public virtual ICollection<CustomerModel> Customers { get; set; } = new List<CustomerModel>();
    }
}
