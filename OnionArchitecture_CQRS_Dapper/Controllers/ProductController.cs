using ApplicationLayer.Commands.Products;
using ApplicationLayer.Queries.Products;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace OnionArchitecture_CQRS_Dapper.Controllers
{
    public class ProductController : BaseController
    {
        [HttpDelete(nameof(DeleteProduct))]
        public async Task<IActionResult> DeleteProduct(DeleteProductByIdCommand command) => Ok(await Mediator.Send(command));
        [HttpGet]
        public async Task<IActionResult> GetAllProducts() => Ok(await Mediator.Send(new GetAllProductsQuery()));
    }
}
