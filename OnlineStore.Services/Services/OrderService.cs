using OnlineStore.Persistence.Entities;
using OnlineStore.Persistence.Repositories;
using OnlineStore.Services.Interfaces;
using OnlineStore.Services.Models;

namespace OnlineStore.Services.Services
{
    public class OrderService : IOrderService
    {
        public IGenericRepository<Order> _orderRepository;
        public OrderService(IGenericRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderModel>> Get()
        {
          var orderEntities = await _orderRepository.GetAllAsync();

          var modelList = new List<OrderModel>();

            foreach (var orderEntity in orderEntities)
            {
                var orderModel = EntityToModel(orderEntity);

                modelList.Add(orderModel);
            }

            return modelList;
        }

        public async Task<OrderModel> GetById(int id)
        {
            var entity = await _orderRepository.GetByIdAsync(id);

            var orderModel = new OrderModel();

            if (entity == null)
            {
                return orderModel;
            }

            orderModel = EntityToModel(entity);

            return orderModel;
        }

        public async Task AddOrder(OrderModel orderModel)
        {
            var orderEntity = new Order
            {
                CustomerId = orderModel.CustomerId,
                OrderDate = orderModel.OrderDate,
                TotalAmountWithoutVat = orderModel.TotalAmountWithoutVat,
                TotalAmountWithVat = orderModel.TotalAmountWithVat,
                Remarks = orderModel.Remarks,
            };

            await _orderRepository.AddAsync(orderEntity);

            foreach (var orderLine in orderModel.OrderLines)
            {
                var orderLineEntity = new OrderLine
                {
                    OrderId = orderEntity.Id,
                    ProductId= orderLine.ProductId,
                    Quantity = orderLine.Quantity,
                    PriceWithoutVat = orderLine.PriceWithoutVat,
                    PriceWithVat = orderLine.PriceWithVat
                };

                orderEntity.OrderLines.Add(orderLineEntity);
            }

            await _orderRepository.UpdateAsync(orderEntity);
        }

        private OrderModel EntityToModel(Order orderEntity)
        {
            var orderModel = new OrderModel
            {
                Id = orderEntity.Id,
                CustomerId = orderEntity.CustomerId,
                OrderDate = orderEntity.OrderDate,
                TotalAmountWithoutVat = orderEntity.TotalAmountWithoutVat,
                TotalAmountWithVat = orderEntity.TotalAmountWithVat,
                Remarks = orderEntity.Remarks,
            };

            foreach (var orderLine in orderEntity.OrderLines)
            {
                var orderLineModel = new OrderLineModel
                {
                    Id = orderLine.Id,
                    OrderId = orderLine.OrderId,
                    PriceWithoutVat = orderLine.PriceWithoutVat,
                    PriceWithVat = orderLine.PriceWithVat,
                    ProductId = orderLine.ProductId,
                    Quantity = orderLine.Quantity
                };
                orderModel.OrderLines.Add(orderLineModel);
            }

            foreach (var invoice in orderEntity.Invoices)
            {
                var invoiceModel = new InvoiceModel
                {
                    Id = invoice.Id,
                    TotalAmountWithoutVat = invoice.TotalAmountWithoutVat,
                    TotalAmountWithVat = invoice.TotalAmountWithVat,
                    CustomerId = invoice.CustomerId,
                    InvoiceDate = invoice.InvoiceDate,
                    InvoiceNumber = invoice.InvoiceNumber,
                    OrderId = invoice.OrderId
                };

                foreach (var payment in invoice.Payments)
                {
                    var paymentModel = new PaymentModel
                    {
                        Id = payment.Id,
                        InvoiceId = payment.InvoiceId,
                        IsSuccessful = payment.IsSuccessful,
                        PaymentDate = payment.PaymentDate,
                        PaymentMethodId = payment.PaymentMethodId
                    };

                    invoiceModel.Payments.Add(paymentModel);
                }

                orderModel.Invoices.Add(invoiceModel);
            }

            return orderModel;
        }
    }
}
