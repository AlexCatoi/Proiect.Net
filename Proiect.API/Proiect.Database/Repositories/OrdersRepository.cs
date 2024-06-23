
using Proiect.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proiect.Database.Context;
using Proiect.Database.Dtos.Request;
using Proiect.Database.QueryExtensions;
using Microsoft.EntityFrameworkCore;
namespace Proiect.Database.Repositories
{
    public class OrdersRepository : BaseRepository
    {
        public OrdersRepository(ProiectDBContext temaDbContext) : base(temaDbContext)
        {
        }

        public void Add(Order order)
        {
            labProjectDbContext.Orders.Add(order);
            labProjectDbContext.SaveChanges();
        }
        private IQueryable<Order> GetOrdersQuery(GetOrderRequest payload)
        {
            var query = labProjectDbContext.Orders

                .Where(e => e.DateDeleted == null)
                .WhereStatus(payload);

            return query;

        }
        public List<Order> GetOrders(GetOrderRequest payload)
        {
            var results = GetOrdersQuery(payload)
                .AsNoTracking()
                .ToList();

            return results;
        }
        public int CountOrders(GetOrderRequest payload)
        {
            var count = GetOrdersQuery(payload)
                .Count();

            return count;
        }
    }
}
