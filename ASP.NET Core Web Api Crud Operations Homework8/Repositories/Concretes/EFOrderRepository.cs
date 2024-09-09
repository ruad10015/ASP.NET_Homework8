using ASP.NET_Homework8.Data;
using ASP.NET_Homework8.Entities;
using ASP.NET_Homework8.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Homework8.Repositories.Concretes
{
    public class EFOrderRepository:IOrderRepository
    {
        private readonly ShopDBContext? _context;

        public EFOrderRepository(ShopDBContext? context)
        {
            _context = context;
        }

        public async Task AddAsync(Order? order)
        {
            await _context!.Orders!.AddAsync(order!);
            await _context!.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var order = _context!.Orders!.FirstOrDefault(p => p.Id == id);
            _context!.Orders!.Remove(order!);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _context!.Orders!.ToListAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            var order = _context!.Orders!.FirstOrDefault(p => p.Id == id);
            return order!;
        }

        public async Task UpdateAsync(Order? order)
        {
            _context!.Orders!.Update(order!);
            await _context!.SaveChangesAsync();
        }
    }
}
