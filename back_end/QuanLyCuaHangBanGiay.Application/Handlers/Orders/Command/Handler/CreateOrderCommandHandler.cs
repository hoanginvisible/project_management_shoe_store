using Dapper;
using Data.Interfaces;
using Domain.Enums;
using MediatR;

namespace Service.Handlers.Orders.Command.Handler
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, string>
    {
        private readonly IDapperHelper _dapperHelper;

        public CreateOrderCommandHandler(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public async Task<string> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            string query = $@"
                SELECT SUBSTRING(MAX(Code), 3, LEN(MAX(Code))) AS Code FROM [Order]
            ";
            string result = await _dapperHelper.ExecuteReturnScalar<string>(query);
            string code = "HD" + (Convert.ToInt32(result) + 1);
            string queryInsertOrder = $@"
                INSERT [Order] (Id, Code, Status, CreatedDate, LastModifiedDate) VALUES (@Id, @Code, @Status, @CreateDate, @LastModifiedDate) 
            ";

            var parameters = new DynamicParameters();
            parameters.Add("@Id", Guid.NewGuid().ToString());
            parameters.Add("@Code", code);
            parameters.Add("@Status", OrderStatus.PendingPayment);
            parameters.Add("@CreateDate", DateTime.Now);
            parameters.Add("@LastModifiedDate", DateTime.Now);
            await _dapperHelper.ExecuteNoReturn(queryInsertOrder, parameters);
            // await _repository.Insert(order);
            return await Task.FromResult("ok");
            // return null;
        }
    }
}