using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Services.Models;

namespace OnlineStore.Services.Interfaces
{
    public interface IOrderService
    {
        Task AddOrder(OrderModel orderModel);
        Task<IEnumerable<OrderModel>> Get();
        Task<OrderModel> GetById(int id);
        //Task Update(int id, OrderModel model);
        //Task Delete(int id);
    }
}
