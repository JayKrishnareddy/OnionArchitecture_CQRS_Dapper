using ApplicationLayer.Commands.Orders;
using ApplicationLayer.Queries.Orders;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OnionArchitecture_CQRS_Dapper.Controllers
{
    public class OrderController : BaseController
    {
        /// <summary>
        /// Save newly added order to database
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost(nameof(SaveOrderData))]
        public async Task<IActionResult> SaveOrderData(CreateOrUpdateOrderCommand command) => Ok(await Mediator.Send(command));
        /// <summary>
        /// Fetch all data from the Orders table.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllOrders() => Ok(await Mediator.Send(new GetAllOrdersQuery()));
    }
}
