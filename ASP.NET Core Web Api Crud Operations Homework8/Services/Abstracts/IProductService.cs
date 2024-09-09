using ASP.NET_Homework8.Entities;

namespace ASP.NET_Homework8.Services.Abstracts
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task UpdateAsync(Product? product);
        Task AddAsync(Product? product);
        Task DeleteAsync(int id);
    }
}
