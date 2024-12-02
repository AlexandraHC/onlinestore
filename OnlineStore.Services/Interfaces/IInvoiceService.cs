using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Services.Models;

namespace OnlineStore.Services.Interfaces
{
    public interface IInvoiceService
    {
        Task Add(InvoiceModel model);
        Task<string> GetNextInvoiceNumber();
        Task<InvoiceModel> GetInvoiceById(int invoiceId);
    }
}
