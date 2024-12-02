namespace OnlineStore.Services.Models
{
    public class OrderModel
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmountWithoutVat { get; set; }

        public decimal TotalAmountWithVat { get; set; }

        public string? Remarks { get; set; }

        public virtual ICollection<InvoiceModel> Invoices { get; set; } = new List<InvoiceModel>();

        public virtual ICollection<OrderLineModel> OrderLines { get; set; } = new List<OrderLineModel>();
    }
}
