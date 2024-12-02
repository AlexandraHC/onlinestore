using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Persistence.Entities;

namespace OnlineStore.Services.Models
{
    public class InvoiceModel
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int CustomerId { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string? InvoiceNumber { get; set; }

        public decimal TotalAmountWithoutVat { get; set; }

        public decimal TotalAmountWithVat { get; set; }

        public virtual ICollection<PaymentModel> Payments { get; set; } = new List<PaymentModel>();
    }
}
