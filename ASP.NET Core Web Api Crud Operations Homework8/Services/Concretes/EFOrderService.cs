using ASP.NET_Homework8.Entities;
using ASP.NET_Homework8.Repositories.Abstracts;
using ASP.NET_Homework8.Services.Abstracts;

namespace ASP.NET_Homework8.Services.Concretes
{
    public class EFOrderService:IOrderService
    {
        private readonly IOrderRepository? _orderService;
        public EFOrderService(IOrderRepository? orderService)
        {
            _orderService = orderService;
        }

        public async Task AddAsync(Order? order)
        {
            await _orderService!.AddAsync(order);
        }

        public async Task DeleteAsync(int id)
        {
            await _orderService!.DeleteAsync(id);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await _orderService!.GetAllAsync();
        }

        public async Task<Order> GetByIdAsync(int id)
        {
            return await _orderService!.GetByIdAsync(id);
        }

        public async Task UpdateAsync(Order? order)
        {
            await _orderService!.UpdateAsync(order);
        }
    }
}
