using Data.Interfaces;
using MediatR;

namespace Service.Handlers.Colors.Queries
{
    public class GetAllColorQuery : IRequest<IEnumerable<ColorDto>>
    {
    }

    public class GetColorQueryHandler : IRequestHandler<GetAllColorQuery, IEnumerable<ColorDto>>
    {
        private readonly IDapperHelper _dapperHelper;

        public GetColorQueryHandler(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public async Task<IEnumerable<ColorDto>> Handle(GetAllColorQuery request, CancellationToken cancellationToken)
        {
            string query = $@"
            SELECT Id, Code, Name FROM Color
            ";
            return await _dapperHelper.ExecuteSqlReturnList<ColorDto>(query);
        }
    }
}