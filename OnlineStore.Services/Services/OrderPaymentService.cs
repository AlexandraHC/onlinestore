using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using OnlineStore.Persistence.Entities;
using OnlineStore.Persistence.Repositories;
using OnlineStore.Services.Interfaces;
using OnlineStore.Services.Models;

namespace OnlineStore.Services.Services
{
    public class OrderPaymentService : IOrderPaymentService
    {
        private IOrderService _orderService;
        private IInvoiceService _invoiceService;
        private IPaymentMethodService _paymentMethodService;

        public OrderPaymentService(IOrderService orderService, IInvoiceService invoiceService, IPaymentMethodService paymentMethodService)
        {
            _orderService = orderService;
            _invoiceService = invoiceService;
            _paymentMethodService = paymentMethodService;
        }

        public async Task<InvoiceModel> GenerateInvoiceForOrder(int orderId)
        {
            var invoiceModel = new InvoiceModel();

            if (orderId < 1)
            {
                return invoiceModel;
            }

            var order = await _orderService.GetById(orderId);

            if(order == null) 
            {
                return invoiceModel;
            }

            invoiceModel.InvoiceDate = DateTime.Now;
            invoiceModel.OrderId = order.Id;
            invoiceModel.CustomerId = order.CustomerId;
            invoiceModel.TotalAmountWithoutVat = order.TotalAmountWithoutVat;
            invoiceModel.TotalAmountWithVat = order.TotalAmountWithVat;
            invoiceModel.InvoiceNumber = await _invoiceService.GetNextInvoiceNumber();

            invoiceModel.Payments.Add(new PaymentModel
            {
                PaymentDate = DateTime.Now,
                IsSuccessful = true,
                PaymentMethodId = (await _paymentMethodService.Get()).FirstOrDefault().Id
            });

            return invoiceModel;
        }
    }
}
