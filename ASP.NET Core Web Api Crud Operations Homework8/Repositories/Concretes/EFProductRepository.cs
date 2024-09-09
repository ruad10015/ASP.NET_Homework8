using ASP.NET_Homework8.Data;
using ASP.NET_Homework8.Entities;
using ASP.NET_Homework8.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace ASP.NET_Homework8.Repositories.Concretes
{
    public class EFProductRepository : IProductRepository
    {
        private readonly ShopDBContext? _context;
        public EFProductRepository(ShopDBContext? context)
        {
            _context = context;
        }

        public async Task AddAsync(Product? product)
        {
            await _context!.Products!.AddAsync(product!);
            await _context!.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var product = _context!.Products!.FirstOrDefault(p => p.Id == id);
            _context!.Products!.Remove(product!);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context!.Products!.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            var product = _context!.Products!.FirstOrDefault(p => p.Id == id);
            return product!;
        }

        public async Task UpdateAsync(Product? product)
        {
             _context!.Products!.Update(product!);
            await _context!.SaveChangesAsync();
        }
    }
}
