using Proiect.Core.Mapping;
using Proiect.Database.Dtos.Request;
using Proiect.Database.Dtos.Response;
using Proiect.Database.Repositories;
using Proiect.Database.Entities;
using Proiect.Database.Context;

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

        public void UpdateOrder(UpdateOrderRequest payload)
        {
            var dbContext = new ProiectDBContext();

            var existingOrder = dbContext.Orders.FirstOrDefault(o => o.OrderId == payload.OrderId);
            
            if (existingOrder == null)
            {
                
                return;
            }
            existingOrder.DateUpdated = DateTime.UtcNow;
            existingOrder.CustomerId = payload.AssignedCustomerIds;
            existingOrder.EmployeeId = payload.AssignedEmployeeIds;
            existingOrder.Status = (Database.Enums.OrderStatuses)payload.Status;

            orderRepository.Update(existingOrder);
        }
        public void DeleteOrder(DeleteOrderRequest payload)
        {
            var dbContext = new ProiectDBContext();

            var existingOrder = dbContext.Orders.FirstOrDefault(o => o.OrderId == payload.OrderId);

            if (existingOrder == null)
            {
                //throw exception
                return;
            }
            if(existingOrder.Customer!=null || existingOrder.Employee!=null)
            {
                //throw exception
                return;
            }
            orderRepository.Delete(existingOrder);
        }


      
    }
    }

