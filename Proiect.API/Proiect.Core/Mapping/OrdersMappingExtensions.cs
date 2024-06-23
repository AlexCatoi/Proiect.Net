using Proiect.Database.Dtos.Request;
using Proiect.Database.Dtos.Common;
using Proiect.Database.Entities;

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
            result.Id = entity.Id;
            result.OrderDate = entity.OrderDate;
            result.Status = entity.Status;

            result.Customer = new ShortCustomerDto();

            if (entity.Customer == null)
                result.Customer = null;
            else
            {
                result.Customer.Id = entity.Customer.Id;
                result.Customer.FirstName = entity.Customer.FirstName;
                result.Customer.LastName = entity.Customer.LastName;
            }

            return result;
        }
    }
}
