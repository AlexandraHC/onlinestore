using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Services.Models;

namespace OnlineStore.Services.Interfaces
{
    public interface IStockService
    {
        Task Add(StockModel model);
        Task<IEnumerable<StockModel>> Get();
        Task<StockModel> GetById(int id);
        Task Update(int id, StockModel model);
        Task Delete(int id);
    }
}
