using Dapper;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationLayer.Commands.Orders
{
    public class CreateOrUpdateOrderCommand : IRequest<string>
    {
        public int OrderId { get; set; }
        [Required]
        public string OrderDetails { get; set; }
        
        public class CreateOrUpdateOrderCommandHandler : IRequestHandler<CreateOrUpdateOrderCommand, string>
        {
            public bool IsActive { get; set; }
            public DateTime OrderedDate { get; set; }
            private readonly IConfiguration configuration;
            public CreateOrUpdateOrderCommandHandler(IConfiguration configuration)
            {
                this.configuration = configuration;
            }
            public async Task<string> Handle(CreateOrUpdateOrderCommand command, CancellationToken cancellationToken)
            {
                if (command.OrderId > 0)
                {
                    var sql = "Update dbo.rders set OrderDetails = @OrderDetails Where OrderId = @OrderId";
                    using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var result = await connection.ExecuteAsync(sql, command);
                        return "Order Details Updated";
                    }
                }
                else
                {
                    var sql = "Insert into dbo.Orders (OrderDetails,IsActive,OrderedDate) VALUES (@OrderDetails,@IsActive,@OrderedDate)";
                    using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
                    {
                        connection.Open();
                        var result = await connection.ExecuteAsync(sql, new { OrderDetails = command.OrderDetails,IsActive =1,OrderedDate = DateTime.Now });
                        return "Order Detais Created" ;
                    }
                }
            }
        }
    }
}
