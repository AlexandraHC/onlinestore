using OnlineStore.Persistence.Entities;
using OnlineStore.Persistence.Repositories;
using OnlineStore.Services.Interfaces;
using OnlineStore.Services.Models;

namespace OnlineStore.Services.Services
{
    public class CustomerService : ICustomerService
    {
        public IGenericRepository<Customer> _customerRepository;

        public CustomerService(IGenericRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task AddCustomerToUser(CustomerModel model)
        {
            var customerEntity = new Customer
            {
                UserId = model.UserId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                DateOfBirth = model.DateOfBirth,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber
            };

            foreach(var address in model.Addresses)
            {
                var addressEntity = new Address
                {
                    City = address.City,
                    Country = address.Country,
                    PostalCode = address.PostalCode,
                    Street = address.Street,
                    StreetNumber = address.StreetNumber
                };

                customerEntity.Addresses.Add(addressEntity);
            }

            await _customerRepository.AddAsync(customerEntity);
        }
    }
}
