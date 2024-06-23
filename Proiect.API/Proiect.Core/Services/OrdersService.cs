using Proiect.Core.Mapping;
using Proiect.Database.Dtos.Request;
using Proiect.Database.Dtos.Response;
using Proiect.Database.Repositories;
using Proiect.Database.Entities;

namespace Proiect.Core.Services
{
    public class OrdersService
    {
        private OrdersRepository orderRepository { get; set; }

        public OrdersService(OrdersRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public void AddOrder(AddOrderRequest payload)
        {
            var project = payload.ToEntity();

            orderRepository.Add(project);
        }
       

        public GetOrderResponse GetOrders(GetOrderRequest payload)
        {
            var orders = orderRepository.GetOrders(payload);

            var result = new GetOrderResponse();
            result.Orders = orders.ToOrderDtos();
            result.Count = orderRepository.CountOrders(payload);

            return result;
        }
    }
}
