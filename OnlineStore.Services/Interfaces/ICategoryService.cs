using OnlineStore.Services.Models;

namespace OnlineStore.Services.Interfaces
{
    public interface ICategoryService
    {
        Task Add(CategoryModel model);
        Task<IEnumerable<CategoryModel>> GetAll();
        Task<CategoryModel> GetById(int id);
        Task Update(int id, CategoryModel model);
        Task Delete(int id);
    }
}
