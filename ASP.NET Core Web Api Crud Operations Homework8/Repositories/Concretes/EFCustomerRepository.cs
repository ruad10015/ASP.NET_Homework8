using ASP.NET_Homework8.Data;
using ASP.NET_Homework8.Entities;
using ASP.NET_Homework8.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Homework8.Repositories.Concretes
{
    public class EFCustomerRepository : ICustomerRepository
    {
        private readonly ShopDBContext? _context;

        public EFCustomerRepository(ShopDBContext? context)
        {
            _context = context;
        }

        public async Task AddAsync(Customer? customer)
        {
            await _context!.Customers!.AddAsync(customer!);
            await _context!.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = _context!.Customers!.FirstOrDefault(p => p.Id == id);
            _context!.Customers!.Remove(customer!);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Customer>> GetAllAsync()
        {
            return await _context!.Customers!.ToListAsync();
        }
        public async Task<Customer> GetByIdAsync(int id)
        {
            var customer = _context!.Customers!.FirstOrDefault(p => p.Id == id);
            return customer!;
        }
        public async Task UpdateAsync(Customer? customer)
        {
            _context!.Customers!.Update(customer!);
            await _context!.SaveChangesAsync();
        }
    }
}
