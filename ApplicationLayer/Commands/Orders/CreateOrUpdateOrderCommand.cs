using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationLayer.Commands.Orders
{
    public class CreateOrUpdateOrderCommand : IRequest<int>
    {
        public int OrderId { get; set; }
        [Required]
        public string OrderDetails { get; set; }
        public class CreateOrUpdateOrderCommandHandler : IRequestHandler<CreateOrUpdateOrderCommand, int>
        {
            private readonly IConfiguration configuration;
            public CreateOrUpdateOrderCommandHandler(IConfiguration configuration)
            {
                this.configuration = configuration;
            }
            public async Task<int> Handle(CreateOrUpdateOrderCommand command, CancellationToken cancellationToken)
            {
                if (command.OrderId > 0)
                {
                    var sql = "Update Orders set OrderDetails = @OrderDetails Where OrderId = @OrderId";
                    using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var result = await connection.ExecuteAsync(sql, command);
                        return result;
                    }
                }
                else
                {
                    var sql = "Insert into Orders (OrderDetails) VALUES (@OrderDetails)";
                    using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var result = await connection.ExecuteAsync(sql, new { ClientName = command.OrderDetails });
                        return result;
                    }
                }
            }
        }
    }
}
