using Data.Interfaces;
using MediatR;

namespace Service.Handlers.Products.Queries
{
    public record GetTopTwentyProductHotQuery : IRequest<IEnumerable<ProductTopTwentyHotDto>>;

    public class
        GetTopTwentyProductHotQueryHandler : IRequestHandler<GetTopTwentyProductHotQuery,
            IEnumerable<ProductTopTwentyHotDto>>
    {
        private readonly IDapperHelper _dapperHelper;

        public GetTopTwentyProductHotQueryHandler(IDapperHelper dapperHelper)
        {
            this._dapperHelper = dapperHelper;
        }

        public async Task<IEnumerable<ProductTopTwentyHotDto>> Handle(GetTopTwentyProductHotQuery request,
            CancellationToken cancellationToken)
        {
            string query = $@"
                SELECT TOP 20 pd.Id, p.Code, p.Name, pd.Price, pd.Quantity, i.Path AS Image, c.Name AS Color FROM ProductDetail AS pd
                JOIN Product AS p ON pd.IdProduct = p.id
                JOIN Images AS i ON i.Id = pd.IdImage
                JOIN Color AS c ON c.Id = pd.IdColor
                JOIN OrderDetails AS od ON od.IdProductDetail = pd.Id
                WHERE pd.Quantity > 0
                GROUP BY pd.Id, p.Code, p.Name, pd.Price, pd.Quantity, i.Path, c.Name
                ORDER BY SUM(od.Quantity) DESC
            ";
            return await _dapperHelper.ExecuteSqlReturnList<ProductTopTwentyHotDto>(query);
        }
    }
}