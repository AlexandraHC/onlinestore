using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Services.Models;

namespace OnlineStore.Services.Interfaces
{
    public interface IProductSupplierService
    {
        Task Add(ProductSupplierModel model);
        Task<IEnumerable<ProductSupplierModel>> Get();
        Task<ProductSupplierModel> GetById(int id);
        Task Update(int id, ProductSupplierModel model);
        Task Delete(int id);
    }
}
