using HireLatamTest.Data;
using HireLatamTest.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace HireLatamTest.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;
        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public Task<List<Product>> GetAsync()
        {
            return _dbContext.Products.ToListAsync();
        }

        public async Task<Product> CreateAsync(string name, decimal price)
        {
            Product product = new Product(name, price);
            _dbContext.Products.Add(product);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = await _dbContext.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }

            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
