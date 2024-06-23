using Proiect.Database.Entities;
using Proiect.Database.Dtos.Common;
using Proiect.Database.Dtos.Request;
using Proiect.Database.Enums;

namespace Proiect.Database.QueryExtensions
{
    public static class OrdersQueryExtensions
    {
        public static IQueryable<Order> WhereStatus(this IQueryable<Order> query, GetOrderRequest payload)
        {
            if (payload.Status == null)
                return query;

            query = query.Where(e => e.Status == payload.Status);

            return query;
        }


        public static IQueryable<Order> WhereAssignedUserIds(this IQueryable<Order> query, GetOrderRequest payload)
        {
            if (payload.AssignedCustomerIds == null)
                return query;

            query = query.Where(e => payload.AssignedCustomerIds==e.CustomerId);

            return query;
        }
        public static IQueryable<Order> WhereAssignedEmployeeIds(this IQueryable<Order> query, GetOrderRequest payload)
        {
            if (payload.AssignedEmployeeIds == null)
                return query;

            query = query.Where(e => payload.AssignedEmployeeIds == e.EmployeeId);

            return query;
        }
    }
}
