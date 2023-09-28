using Data.Interfaces;
using MediatR;

namespace Service.Handlers.Products.Queries
{
    public class GetAllProductQuery : IRequest<IEnumerable<ProductDto>>
    {
    }

    public class GetBrandQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<ProductDto>>
    {
        private readonly IDapperHelper _dapperHelper;

        public GetBrandQueryHandler(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public async Task<IEnumerable<ProductDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            string query = $@"
            SELECT Id, Code, Name FROM Product
            ";
            return await _dapperHelper.ExecuteSqlReturnList<ProductDto>(query);
        }
    }
}