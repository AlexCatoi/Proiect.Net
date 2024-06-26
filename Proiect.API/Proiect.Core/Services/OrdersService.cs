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
            try
            {
                var order = new Order
                {
                    CustomerId = payload.CustomerId,
                    EmployeeId = payload.EmployeeId,
                    OrderDate = payload.OrderDate,
                    Status = payload.Status,
                    Total = payload.Total,
                    DateCreated = DateTime.UtcNow,
                    DateUpdated = DateTime.UtcNow,
                    OrderProducts = new List<OrderProducts>()  // Initialize the collection
                };

                // Iterate through each product in the payload and add it to OrderProducts
                foreach (var productDto in payload.OrderProducts)
                {
                    var orderProduct = new OrderProducts
                    {
                        ProductId = productDto.ProductId,
                        Quantity = productDto.Quantity
                    };

                    order.OrderProducts.Add(orderProduct);
                }

                orderRepository.Add(order);
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
            existingOrder.Total = payload.Total;
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

