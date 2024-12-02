using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Services.Models;

namespace OnlineStore.Services.Interfaces
{
    public interface IOrderPaymentService
    {
        Task<InvoiceModel> GenerateInvoiceForOrder(int orderId);
    }
}
