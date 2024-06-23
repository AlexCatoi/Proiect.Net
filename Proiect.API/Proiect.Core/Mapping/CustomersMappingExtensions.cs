using Proiect.Database.Dtos.Common;
using Proiect.Database.Dtos.Request;
using Proiect.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proiect.Core.Mapping
{
    public static class CustomersMappingExtensions
    {
        public static Customer ToEntity(this AddCustomerRequest dto)
        {
            if (dto == null) return null;

            var result = new Customer();

            result.DateCreated = DateTime.UtcNow;
            result.DateUpdated = DateTime.UtcNow;
            result.FirstName = dto.FirstName;
            result.LastName = dto.LastName;
            result.Email = dto.Email;
            result.Phone = dto.Phone;

            return result;
        }

        public static List<ShortCustomerDto> ToCustomerDtos(this List<Customer> entities)
        {
            var results = entities.Select(e => e.ToCustomerDto()).ToList();

            return results;
        }
        private static ShortCustomerDto ToCustomerDto(this Customer entity)
        {
            if (entity == null) return null;

            var result = new ShortCustomerDto();
            result.CustomerId = entity.CustomerId;
            result.FirstName = entity.FirstName;
            result.LastName = entity.LastName;
            result.Email= entity.Email;
            result.Phone = entity.Phone;
            return result;
        }
    }
}
