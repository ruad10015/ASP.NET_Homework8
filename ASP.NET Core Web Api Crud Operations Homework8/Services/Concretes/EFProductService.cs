using ASP.NET_Homework8.Entities;
using ASP.NET_Homework8.Repositories.Abstracts;
using ASP.NET_Homework8.Services.Abstracts;

namespace ASP.NET_Homework8.Services.Concretes
{
    public class EFProductService : IProductService
    {
        private readonly IProductRepository? _productService;
        public EFProductService(IProductRepository? productService)
        {
            _productService = productService;
        }

        public async Task AddAsync(Product? product)
        {
            await _productService!.AddAsync(product);
        }

        public async Task DeleteAsync(int id)
        {
            await _productService!.DeleteAsync(id);
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productService!.GetAllAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
           return await _productService!.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Product? product)
        {
            await _productService!.UpdateAsync(product);
        }
    }
}
