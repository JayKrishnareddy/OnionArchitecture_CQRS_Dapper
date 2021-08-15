using Dapper;
using DomainLayer;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationLayer.Queries
{
    public class GetAllOrdersQuery : IRequest<IList<Order>>
    {
        public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrdersQuery, IList<Order>>
        {
            private readonly IConfiguration _configuration;
            public GetAllOrderQueryHandler(IConfiguration configuration)
            {
                _configuration = configuration;
            }
            public async Task<IList<Order>> Handle(GetAllOrdersQuery query, CancellationToken cancellationToken)
            {
                var sql = "Select * from Orders";
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
                {
                    connection.Open();
                    var result = await connection.QueryAsync<Order>(sql);
                    return result.ToList();
                }
            }
        }
    }
}
