using System.Net.NetworkInformation;
using Proiect.Core.Services;
using Proiect.Database.Dtos.Request;
using Microsoft.AspNetCore.Authorization;
using Proiect.Database.Entities;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using Proiect.API.Controllers;

namespace Proiect.Api.Controllers
{
    [Route("api/projects")]
    public class OrderController : BaseController
    {
        private OrdersService projectsService { get; set; }

        public OrderController(OrdersService projectsService)
        {
            this.projectsService = projectsService;
        }

        [HttpPost]
        [Route("add")]
        public IActionResult AddOrder([FromBody] AddOrderRequest payload)
        {
            projectsService.AddOrder(payload);

            return Ok("Order has been successfully added");
        }

        [HttpGet]
        [Route("get-details")]
        [Authorize(Roles = "Admin")]
        public IActionResult GetTOrderDetails([FromRoute] GetOrderRequest orders)
        {
            var result = projectsService.GetOrders(orders);

            return Ok(result);
        }
        [HttpPut]
        [Route("Update")]
       // [Authorize(Roles ="Admin")]
        public IActionResult UpdateOrderDetails([FromBody] UpdateOrderRequest order)
        {
            projectsService.UpdateOrder(order);

            return Ok("Order has been successfully updated");
        }

        [HttpDelete]
        [Route("Delete")]
       // [Authorize(Roles = "Admin")]
        public IActionResult DeleteOrderDetails([FromBody] DeleteOrderRequest order)
        {
            projectsService.DeleteOrder(order);

            return Ok("Order has been successfully deleted");
        }
    }
}
