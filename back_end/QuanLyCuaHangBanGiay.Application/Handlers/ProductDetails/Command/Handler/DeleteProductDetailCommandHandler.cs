using Dapper;
using Data.Interfaces;
using MediatR;

namespace Service.Handlers.ProductDetails.Command.Handler
{
    public class DeleteProductDetailCommandHandler : IRequestHandler<DeleteProductDetailCommand, string>
    {
        private readonly IDapperHelper _dapperHelper;

        public DeleteProductDetailCommandHandler(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public Task<string> Handle(DeleteProductDetailCommand request, CancellationToken cancellationToken)
        {
            var query = $@"
                DELETE FROM ProductDetail
                WHERE ProductDetail.Id = :Id
                
            ";
            var parameter = new DynamicParameters();
            parameter.Add("@Id", request.Id);
            _dapperHelper.ExecuteNoReturn(query, parameter);
            return Task.FromResult(request.Id!);
        }
    }
}