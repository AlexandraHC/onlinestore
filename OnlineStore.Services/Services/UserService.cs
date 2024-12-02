using OnlineStore.Persistence.Entities;
using OnlineStore.Persistence.Repositories;
using OnlineStore.Services.Interfaces;
using OnlineStore.Services.Models;
using OnlineStore.Services.Utils;

namespace OnlineStore.Services.Services
{
    public class UserService : IUserService
    {
        private IGenericRepository<User> _userRepository;

        public UserService(IGenericRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Add(User user)
        {
            await _userRepository.AddAsync(user);
        }

        public async Task<bool> AddUser(CreateUserModel model)
        {
            if (model == null)
            {
                return false;
            }

            if (model.Password != model.ConfirmPassword)
            {
                return false;
            }

            var newUserEntity = new User
            {
                UserName = model.UserName,
                Email = model.Email,
                Password = StringUtils.Base64Encode(model.Password)
            };

            await _userRepository.AddAsync(newUserEntity);

            return true;
        }

        public async Task<IEnumerable<UserModel>> GetAll()
        {
            var users = await _userRepository.GetAllAsync();

            var modelList = new List<UserModel>();
            foreach (var user in users)
            {
                var userModel = EntityToModel(user);   
                modelList.Add(userModel);
            }
            return modelList;
        }

        public async Task<UserModel> GetByEmail(string email)
        {
            var user = (await _userRepository.GetAllAsync()).FirstOrDefault(x => x.Email == email);

            var userModel = new UserModel();

            if(user == null)
            {
                return userModel;
            }

            userModel = EntityToModel(user);
            return userModel;
        }

        public async Task<UserModel> GetByEmailAndPassword(string email, string password)
        {
            var userModel = new UserModel();

            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
            {
                return userModel;
            }

            var encodedPassword = StringUtils.Base64Encode(password);

            var userEntity = (await _userRepository.GetAllAsync()).FirstOrDefault(x => x.Email == email && x.Password == encodedPassword);

            if (userEntity == null)
            {
                return userModel;
            }

            userModel.UserName = userEntity.UserName;
            userModel.Id = userEntity.Id;
            userModel.Email = userEntity.Email;

            return userModel;
        }

        public async Task<UserModel> GetById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            var userModel = new UserModel();

            if (user == null)
            {
                return userModel;
            }

            userModel = EntityToModel(user);
            return userModel;
        }

        public async Task<bool> UpdateUser(int id, UpdateUserModel model)
        {
            if (model is null)
            {
                return false;
            }

            var userEntity = await _userRepository.GetByIdAsync(id);
            // if the user does not exist
            if (userEntity == null)
            {
                return false;
            }

            userEntity.UserName = model.UserName;
            userEntity.Email = model.Email;

            // if he/she wants to update the password
            if (!string.IsNullOrEmpty(model.NewPassword))
            {
                // if the new password is not long enough or does not match ConfirmPassword
                if (model.NewPassword.Length <= 5 ||
                    (model.NewPassword != model.ConfirmNewPassword))
                {
                    return false;
                }

                // if the old password is not filled in
                if (string.IsNullOrEmpty(model.Password))
                {
                    return false;
                }

                // if the old password does not match
                if (userEntity.Password != model.Password)
                {
                    return false;
                }

                userEntity.Password = StringUtils.Base64Encode(model.ConfirmNewPassword);
            }

            await _userRepository.UpdateAsync(userEntity);

            return true;
        }

        private UserModel EntityToModel(User user)
        {
            var userModel = new UserModel
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };

            foreach (var customer in user.Customers)
            {
                var customerModel = new CustomerModel
                {
                    Email = customer.Email,
                    CustomerId = customer.Id,
                    DateOfBirth = customer.DateOfBirth,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    PhoneNumber = customer.PhoneNumber,
                    UserId = user.Id
                };

                foreach (var address in customer.Addresses)
                {
                    var addressModel = new AddressModel
                    {
                        AddressId = address.Id,
                        City = address.City,
                        Country = address.Country,
                        CustomerId = customer.Id,
                        PostalCode = address.PostalCode,
                        Street = address.Street,
                        StreetNumber = address.StreetNumber
                    };

                    customerModel.Addresses.Add(addressModel);
                }

                userModel.Customers.Add(customerModel);
            }

            return userModel;
        }
    }
}
