namespace OnlineStore.Services.Models
{
    public class OrderLineModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal PriceWithVat { get; set; }

        public decimal PriceWithoutVat { get; set; }
    }
}
