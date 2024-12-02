using OnlineStore.Services.Models;

namespace OnlineStore.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserModel>> GetAll();
        Task<UserModel> GetById(int id);
        Task<UserModel> GetByEmail(string email);
        Task<bool> AddUser(CreateUserModel model);
        Task<bool> UpdateUser(int id, UpdateUserModel model);
        Task<UserModel> GetByEmailAndPassword(string email, string password);
    }
}
