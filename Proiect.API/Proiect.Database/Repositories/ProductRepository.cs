using System.Collections.Generic;
using System.Linq;
using Proiect.Database.Context;
using Proiect.Database.Entities;

namespace Proiect.Database.Repositories
{
    public class ProductRepository
    {
        private readonly ProiectDBContext _dbContext;

        public ProductRepository(ProiectDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }

        public Product GetById(int id)
        {
            return _dbContext.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public void Update(Product product)
        {
            _dbContext.Products.Update(product);
            _dbContext.SaveChanges();
        }

        public void Delete(Product product)
        {
            _dbContext.Products.Remove(product);
            _dbContext.SaveChanges();
        }
    }
}
