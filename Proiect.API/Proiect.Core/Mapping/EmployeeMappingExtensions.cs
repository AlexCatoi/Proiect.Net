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
    public static class EmployeeMappingExtensions
    {
        public static Employee ToEntity(this AddEmployeeRequest dto)
        {
            if (dto == null) return null;

            var result = new Employee();

            result.EmployementDate = DateTime.UtcNow;
            result.FirstName = dto.FirstName;
            result.LastName = dto.LastName;
            result.Email = dto.Email;
            result.Phone = dto.Phone;

            return result;
        }

        public static List<ShortEmployeeDto> ToEmployeesDtos(this List<Employee> entities)
        {
            var results = entities.Select(e => e.ToEmployeeDto()).ToList();

            return results;
        }
        private static ShortEmployeeDto ToEmployeeDto(this Employee entity)
        {
            if (entity == null) return null;

            var result = new ShortEmployeeDto();
            result.EmployeeId = entity.EmployeeId;
            result.FirstName = entity.FirstName;
            result.LastName = entity.LastName;
            result.Email = entity.Email;
            result.Phone = entity.Phone;
            return result;
        }
    }
}
