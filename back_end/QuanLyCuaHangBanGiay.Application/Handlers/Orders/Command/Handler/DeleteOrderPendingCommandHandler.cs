using Dapper;
using Data.Interfaces;
using MediatR;

namespace Service.Handlers.Orders.Command.Handler
{
    public class DeleteOrderPendingCommandHandler : IRequestHandler<DeleteOrderCommand, string>
    {
        private readonly IDapperHelper _dapperHelper;

        public DeleteOrderPendingCommandHandler(IDapperHelper dapperHelper)
        {
            this._dapperHelper = dapperHelper;
        }

        public Task<string> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            string query = $@"
                DELETE FROM [Order] WHERE Id = @idOrder;
                DELETE FROM OrderDetails WHERE IdOrder = @idOrder
            ";
            var parameter = new DynamicParameters();
            parameter.Add("@idOrder", request.IdOrder);
            _dapperHelper.ExecuteNoReturn(query, parameter);
            return Task.FromResult(request.IdOrder)!;
        }
    }
}