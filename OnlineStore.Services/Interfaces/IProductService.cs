using OnlineStore.Services.Models;

namespace OnlineStore.Services.Interfaces
{
    public interface IProductService
    {
        Task Add(ProductModel model);
        Task<IEnumerable<ProductModel>> Get();
        Task<IEnumerable<ProductModel>> Get(int categoryId, int pageNo, int pageSize);
        Task<ProductModel> GetById(int id);
        Task Update(int id, ProductModel model);
        Task Delete(int id);
    }
}
