using Dapper;
using DomainLayer;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationLayer.Queries.Products
{
    public class GetAllProductsQuery : IRequest<IList<Product>>
    {
        public class GetAllOrderQueryHandler : IRequestHandler<GetAllProductsQuery, IList<Product>>
        {
            private readonly IConfiguration _configuration;
            public GetAllOrderQueryHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var sql = "Select * from Products";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<Product>(sql);
                    return result.ToList();
                }
            }
        }
    }
}
