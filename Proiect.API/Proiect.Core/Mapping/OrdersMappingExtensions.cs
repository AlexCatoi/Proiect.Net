using Proiect.Database.Dtos.Request;
using Proiect.Database.Dtos.Common;
using Proiect.Database.Entities;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Proiect.Database.Context;
namespace Proiect.Core.Mapping
{
    public static class OrdersMappingExtensions
    {
        public static Order ToEntity(this AddOrderRequest dto)
        {
            if (dto == null) return null;
            
            var result = new Order();
            result.OrderDate = dto.OrderDate;

            result.DateCreated = DateTime.UtcNow;
            result.DateUpdated = DateTime.UtcNow;
            result.Status = dto.Status;
            result.CustomerId = dto.CustomerId;
            result.EmployeeId = dto.EmployeeId;
            return result;
        }

        public static List<ShortOrderDto> ToOrderDtos(this List<Order> entities)
        {
            var results = entities.Select(e => e.ToOrderDto()).ToList();

            return results;
        }
        private static ShortOrderDto ToOrderDto(this Order entity)
        {
            if (entity == null) return null;

            var result = new ShortOrderDto();
            result.OrderId = entity.OrderId;
            result.OrderDate = entity.OrderDate;
            result.Status = entity.Status;

           result.CustomerId= entity.CustomerId;
            result.EmployeeId= entity.EmployeeId;

            return result;
        }
    }
}
