namespace OnlineStore.Services.Models
{
    public class PaymentModel
    {
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        public DateTime PaymentDate { get; set; }

        public int PaymentMethodId { get; set; }

        public bool IsSuccessful { get; set; }
    }
}
