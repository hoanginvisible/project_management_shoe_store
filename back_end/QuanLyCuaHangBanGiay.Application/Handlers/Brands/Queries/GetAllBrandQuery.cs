using Data.Interfaces;
using MediatR;

namespace Service.Handlers.Brands.Queries
{
    public class GetAllBrandQuery : IRequest<IEnumerable<BrandDto>>
    {
    }

    public class GetBrandQueryHandler : IRequestHandler<GetAllBrandQuery, IEnumerable<BrandDto>>
    {
        private readonly IDapperHelper _dapperHelper;

        public GetBrandQueryHandler(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public async Task<IEnumerable<BrandDto>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            string query = $@"
            SELECT Id, Code, Name FROM Brand
            ";
            return await _dapperHelper.ExecuteSqlReturnList<BrandDto>(query);
        }
    }
}