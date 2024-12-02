using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Services.Models;

namespace OnlineStore.Services.Interfaces
{
    public interface ISupplierService
    {
        Task Add(SupplierModel model);
        Task<IEnumerable<SupplierModel>> Get();
        Task<SupplierModel> GetById(int id);
        Task Update(int id, SupplierModel model);
        Task Delete(int id);
    }
}
