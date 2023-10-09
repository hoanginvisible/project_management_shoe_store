using Data.Interfaces;
using MediatR;

namespace Service.Handlers.Orders.Queries.Handler
{
    public class
        GetIdOrderPendingPaymentQueryHandler : IRequestHandler<GetIdOrderPendingPaymentQuery, IEnumerable<string>>
    {
        private readonly IDapperHelper _dapperHelper;

        public GetIdOrderPendingPaymentQueryHandler(IDapperHelper dapperHelper)
        {
            this._dapperHelper = dapperHelper;
        }

        public async Task<IEnumerable<string>> Handle(GetIdOrderPendingPaymentQuery request,
            CancellationToken cancellationToken)
        {
            string query = $@"
           SELECT Id FROM [Order]
            ";
            return await _dapperHelper.ExecuteSqlReturnList<string>(query);
        }
    }
}