using Data.Interfaces;
using MediatR;

namespace Service.Handlers.Materials.Queries
{
    public class GetAllMaterialQuery : IRequest<IEnumerable<MaterialDto>>
    {
    }

    public class GetMaterialQueryHandler : IRequestHandler<GetAllMaterialQuery, IEnumerable<MaterialDto>>
    {
        private readonly IDapperHelper _dapperHelper;

        public GetMaterialQueryHandler(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public async Task<IEnumerable<MaterialDto>> Handle(GetAllMaterialQuery request, CancellationToken cancellationToken)
        {
            string query = $@"
            SELECT Id, Code, Name FROM Material
            ";
            return await _dapperHelper.ExecuteSqlReturnList<MaterialDto>(query);
        }
    }
}