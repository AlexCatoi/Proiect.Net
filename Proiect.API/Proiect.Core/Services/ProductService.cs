using Proiect.Database.Context;
using Proiect.Database.Dtos.Common;
using Proiect.Database.Dtos.Request;
using Proiect.Database.Dtos.Response;
using Proiect.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proiect.Core.Services
{
    public class ProductService
    {
        private readonly ProiectDBContext _dbContext;

        public ProductService(ProiectDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProduct(AddProductRequest payload)
        {
            var product = new Product
            {
                DateCreated = DateTime.UtcNow,
                DateUpdated = DateTime.UtcNow,
                Nume = payload.Nume,
                NrBucati = payload.NrBucati,
                Valoare = payload.Valoare,
                Greutate = payload.Greutate,
                Marime = payload.Marime,
                IsActive = payload.IsActive
            };

            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
        }

        public GetProductResponse GetProducts()
        {
            var products = _dbContext.Products.ToList();

            var result = new GetProductResponse
            {
                Products = products.Select(p => new ShortProductDto
                {
                    ProductId = p.ProductId,
                    Nume = p.Nume,
                    NrBucati = p.NrBucati,
                    Valoare = p.Valoare,
                    Greutate = p.Greutate,
                    Marime = p.Marime,
                    IsActive = p.IsActive
                }).ToList(),
                Count = products.Count
            };

            return result;
        }

        public void UpdateProduct(UpdateProductRequest payload)
        {
            var existingProduct = _dbContext.Products.FirstOrDefault(p => p.ProductId == payload.ProductId);

            if (existingProduct != null)
            {
                existingProduct.DateUpdated = DateTime.UtcNow;
                existingProduct.Nume = payload.Nume;
                existingProduct.NrBucati = payload.NrBucati;
                existingProduct.Valoare = payload.Valoare;
                existingProduct.Greutate = payload.Greutate;
                existingProduct.Marime = payload.Marime;
                existingProduct.IsActive = payload.IsActive;

                _dbContext.SaveChanges();
            }
        }

        public void DeleteProduct(int productId)
        {
            var existingProduct = _dbContext.Products.FirstOrDefault(p => p.ProductId == productId);

            if (existingProduct != null)
            {
                _dbContext.Products.Remove(existingProduct);
                _dbContext.SaveChanges();
            }
        }
    }
}
