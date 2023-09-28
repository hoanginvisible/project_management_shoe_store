using Data.Interfaces;
using MediatR;

namespace Service.Handlers.Products.Queries
{
    public class GetAllSizeQuery : IRequest<IEnumerable<SizeDto>>
    {
    }

    public class GetSizeQueryHandler : IRequestHandler<GetAllSizeQuery, IEnumerable<SizeDto>>
    {
        private readonly IDapperHelper _dapperHelper;

        public GetSizeQueryHandler(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public async Task<IEnumerable<SizeDto>> Handle(GetAllSizeQuery request, CancellationToken cancellationToken)
        {
            string query = $@"
            SELECT Id, Code, Name FROM Size
            ";
            return await _dapperHelper.ExecuteSqlReturnList<SizeDto>(query);
        }
    }
}