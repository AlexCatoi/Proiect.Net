using Proiect.Core.Mapping;
using Proiect.Database.Dtos.Request;
using Proiect.Database.Dtos.Response;
using Proiect.Database.Entities;
using Proiect.Database.Repositories;
using System;

namespace Proiect.Core.Services
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(AddProductRequest payload)
        {
            var product = payload.ToEntity();
            _productRepository.Add(product);
        }

        public GetProductResponse GetProducts(GetProductRequest payload)
        {
            var products = _productRepository.GetProducts(payload);
            var result = new GetProductResponse
            {
                Products = products.ToProductDtos(),
                Count = _productRepository.CountProducts(payload)
            };

            return result;
        }

        public void UpdateProduct(UpdateProductRequest payload)
        {
            var existingProduct = _productRepository.GetById(payload.ProductId.Value);

            if (existingProduct != null)
            {
                existingProduct.DateUpdated = DateTime.UtcNow;
                existingProduct.Nume = payload.Nume;
                existingProduct.NrBucati = payload.NrBucati;
                existingProduct.Valoare = payload.Valoare;
                existingProduct.Greutate = payload.Greutate;
                existingProduct.Marime = payload.Marime;
                existingProduct.IsActive = payload.IsActive.Value;

                _productRepository.Update(existingProduct);
            }
        }

        public void DeleteProduct(DeleteProductRequest payload)
        {
            var existingProduct = _productRepository.GetById(payload.ProductId.Value);
            if (existingProduct != null)
            {
                _productRepository.Delete(existingProduct);
            }
        }
    }
}
