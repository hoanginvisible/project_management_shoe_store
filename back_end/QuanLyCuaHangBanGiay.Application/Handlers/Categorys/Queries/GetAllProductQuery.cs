using Data.Interfaces;
using MediatR;

namespace Service.Handlers.Categorys.Queries
{
    public class GetAllCategoryQuery : IRequest<IEnumerable<CategoryDto>>
    {
    }

    public class GetCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<CategoryDto>>
    {
        private readonly IDapperHelper _dapperHelper;

        public GetCategoryQueryHandler(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            string query = $@"
            SELECT Id, Code, Name FROM Category
            ";
            return await _dapperHelper.ExecuteSqlReturnList<CategoryDto>(query);
        }
    }
}