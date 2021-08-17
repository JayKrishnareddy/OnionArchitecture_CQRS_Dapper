using ApplicationLayer.Commands.Products;
using ApplicationLayer.Queries.Products;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OnionArchitecture_CQRS_Dapper.Controllers
{
    public class ProductController : BaseController
    {
        /// <summary>
        /// Delete Product from the Products Table
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete(nameof(DeleteProduct))]
        public async Task<IActionResult> DeleteProduct(DeleteProductByIdCommand command) => Ok(await Mediator.Send(command));
        /// <summary>
        /// Fetch all Product Data from the Database
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts() => Ok(await Mediator.Send(new GetAllProductsQuery()));
    }
}
