using Proiect.Database.Dtos.Common;
using Proiect.Database.Dtos.Request;
using Proiect.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proiect.Core.Mapping
{
    public static class ProductsMappingExtensions
    {
        public static Product ToEntity(this AddProductRequest dto)
        {
            if (dto == null) return null;
            var result = new Product();
            result.DateCreated = DateTime.UtcNow;
            result.DateUpdated = DateTime.UtcNow;
            result.Nume = dto.Nume;
            result.NrBucati = dto.NrBucati;
            result.Valoare = dto.Valoare;
            result.Greutate = dto.Greutate;
            result.Marime = dto.Marime;
            result.IsActive = dto.IsActive;

            return result;
        }

        public static List<ShortProductDto> ToProductDtos(this List<Product> entities)
        {
            var results = entities.Select(e => e.ToProductDto()).ToList();
            return results;
        }

        private static ShortProductDto ToProductDto(this Product entity)
        {
            if (entity == null) return null;

            var result = new ShortProductDto
            {
                ProductId = entity.ProductId,
                Nume = entity.Nume,
                NrBucati = entity.NrBucati,
                Valoare = entity.Valoare,
                Greutate = entity.Greutate,
                Marime = entity.Marime,
                IsActive = entity.IsActive,
            };

            return result;
        }
    }
}
