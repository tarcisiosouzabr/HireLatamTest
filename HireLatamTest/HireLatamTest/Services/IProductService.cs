using HireLatamTest.Data.Entities;

namespace HireLatamTest.Services
{
    public interface IProductService
    {
        Task<Product> CreateAsync(string name, decimal price);
        Task<bool> DeleteAsync(int id);
        Task<List<Product>> GetAsync();
    }
}