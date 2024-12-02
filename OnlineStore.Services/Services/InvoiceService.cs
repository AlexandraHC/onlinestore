using OnlineStore.Persistence.Entities;
using OnlineStore.Persistence.Repositories;
using OnlineStore.Services.Interfaces;
using OnlineStore.Services.Models;

namespace OnlineStore.Services.Services
{
    public class InvoiceService : IInvoiceService
    {
        public IGenericRepository<Invoice> _invoiceRepository;
        public IGenericRepository<Payment> _paymentRepository;

        public InvoiceService(IGenericRepository<Invoice> invoiceRepository, IGenericRepository<Payment> paymentRepository)
        {
            _invoiceRepository = invoiceRepository;
            _paymentRepository = paymentRepository;
        }

        public async Task Add(InvoiceModel model)
        {
            var invoiceEntity = new Invoice
            {
                CustomerId = model.CustomerId,
                InvoiceDate = model.InvoiceDate,
                InvoiceNumber = model.InvoiceNumber,
                OrderId = model.OrderId,
                TotalAmountWithVat = model.TotalAmountWithVat,
                TotalAmountWithoutVat = model.TotalAmountWithoutVat
            };

            await _invoiceRepository.AddAsync(invoiceEntity);

            foreach (var payment in model.Payments)
            {
                invoiceEntity.Payments.Add(new Payment
                {
                    IsSuccessful = payment.IsSuccessful,
                    PaymentDate = payment.PaymentDate,
                    PaymentMethodId = payment.PaymentMethodId
                });
            }

            await _invoiceRepository.UpdateAsync(invoiceEntity);
        }

        public async Task<string> GetNextInvoiceNumber()
        {
            var allInvoices = await _invoiceRepository.GetAllAsync();

            var nextInvoiceNumber = 1;

            if (allInvoices.Any())
            {
                nextInvoiceNumber = allInvoices.Select(x => x.Id).Max() + 1;
            }

            return "OnlineStore " + nextInvoiceNumber;
        }

        public async Task<InvoiceModel> GetInvoiceById(int invoiceId)
        {
            var invoiceEntity = await _invoiceRepository.GetByIdAsync(invoiceId);

            if (invoiceEntity == null)
            {
                return new InvoiceModel();
            }

            var invoiceModel = new InvoiceModel
            {
                Id = invoiceEntity.Id,
                TotalAmountWithoutVat = invoiceEntity.TotalAmountWithVat,
                TotalAmountWithVat = invoiceEntity.TotalAmountWithoutVat,
                CustomerId = invoiceEntity.CustomerId,
                InvoiceDate = invoiceEntity.InvoiceDate,
                InvoiceNumber = invoiceEntity.InvoiceNumber,
                OrderId = invoiceEntity.OrderId
            };

            foreach (var payment in invoiceEntity.Payments)
            {
                invoiceModel.Payments.Add(new PaymentModel
                {
                    PaymentDate = payment.PaymentDate,
                    IsSuccessful = payment.IsSuccessful,
                    PaymentMethodId = payment.PaymentMethodId,
                    InvoiceId = payment.InvoiceId,
                    Id = payment.Id
                });
            }

            return invoiceModel;
        }
    }
}
