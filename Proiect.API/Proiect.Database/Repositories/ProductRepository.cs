using System.Collections.Generic;
using System.Linq;
using Proiect.Database.Context;
using Proiect.Database.Entities;
using Proiect.Database.Dtos.Request;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Proiect.Database.Repositories
{
    public class ProductRepository : BaseRepository
    {
        public ProductRepository(ProiectDBContext temaDbContext) : base(temaDbContext) { }

        public void Add(Product product)
        {
            labProjectDbContext.Products.Add(product);
            labProjectDbContext.SaveChanges();
        }

        private IQueryable<Product> GetProductsQuery(GetProductRequest payload)
        {
            var query = labProjectDbContext.Products
                .Where(p => p.DateDeleted == null);
            if (!string.IsNullOrEmpty(payload.Nume))
            {
                query = query.Where(p => p.Nume.Contains(payload.Nume));
            }

            if (payload.Valoare.HasValue)
            {
                query = query.Where(p => p.Valoare == payload.Valoare.Value);
            }

            if (payload.IsActive.HasValue)
            {
                query = query.Where(p => p.IsActive == payload.IsActive.Value);
            }
            return query;
        }

        public List<Product> GetProducts(GetProductRequest payload)
        {
            var results = GetProductsQuery(payload)
                .AsNoTracking()
                .ToList();

            return results;
        }

        public int CountProducts(GetProductRequest payload)
        {
            var count = GetProductsQuery(payload)
                .Count();

            return count;
        }

        public Product GetById(int id)
        {
            return labProjectDbContext.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public void Update(Product product)
        {
            labProjectDbContext.Products.Update(product);
            labProjectDbContext.SaveChanges();
        }

        public void Delete(Product product)
        {
            labProjectDbContext.Products.Remove(product);
            labProjectDbContext.SaveChanges();
        }
    }
}
