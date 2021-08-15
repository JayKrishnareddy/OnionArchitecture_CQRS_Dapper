using ApplicationLayer.Commands.Orders;
using ApplicationLayer.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OnionArchitecture_CQRS_Dapper.Controllers
{
    public class OrderController : BaseController
    {
        [HttpPost(nameof(SaveOrderData))]
        public async Task<IActionResult> SaveOrderData(CreateOrUpdateOrderCommand command) => Ok(await Mediator.Send(command));
        [HttpGet]
        public async Task<IActionResult> GetAllOrders() => Ok(await Mediator.Send(new GetAllOrdersQuery()));
    }
}
