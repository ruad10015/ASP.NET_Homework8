using ASP.NET_Homework8.Entities;
using ASP.NET_Homework8.Repositories.Abstracts;
using ASP.NET_Homework8.Services.Abstracts;

namespace ASP.NET_Homework8.Services.Concretes
{
    public class EFCustomerService:ICustomerService
    {
        private readonly ICustomerRepository? _customerService;

        public EFCustomerService(ICustomerRepository? customerService)
        {
            _customerService = customerService;
        }

        public async Task AddAsync(Customer? customer)
        {
            await _customerService!.AddAsync(customer);
        }

        public async Task DeleteAsync(int id)
        {
            await _customerService!.DeleteAsync(id);
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _customerService!.GetAllAsync();
        }

        public async Task<Customer> GetByIdAsync(int id)
        {
            return await _customerService!.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Customer? customer)
        {
            await _customerService!.UpdateAsync(customer);
        }
    }
}
