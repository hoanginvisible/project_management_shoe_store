using Data.Interfaces;
using MediatR;

namespace Service.Handlers.ProductDetails.Queries
{
    public record GetAllProductDetailQuery : IRequest<IEnumerable<ProductDetailDto>>
    {
    }

    public class
        GetAllProductDetailQueryHandler : IRequestHandler<GetAllProductDetailQuery, IEnumerable<ProductDetailDto>>
    {
        private readonly IDapperHelper _dapperHelper;

        public GetAllProductDetailQueryHandler(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public async Task<IEnumerable<ProductDetailDto>> Handle(GetAllProductDetailQuery allProductDetailQuery,
            CancellationToken cancellationToken)
        {
            string query = $@"
            SELECT pd.Id, p.Name AS NameProduct, b.Name AS NameBrand, c.Name AS NameCategory, 
            Color.Name AS NameColor, i.Path AS Image, m.Name AS NameMaterial, s.Name AS NameSize, 
            Price, Quantity FROM ProductDetail pd
            LEFT JOIN Product p ON p.Id = pd.IdProduct
            LEFT JOIN Brand b ON b.Id = pd.IdBrand
            LEFT JOIN Category c ON c.Id = pd.IdCategory
            LEFT JOIN Color ON Color.Id = pd.IdColor
            LEFT JOIN Images i ON i.Id = pd.IdImage
            LEFT JOIN Material m ON m.Id = pd.IdMaterial
            LEFT JOIN Size s ON s.Id = pd.IdSize
            ORDER BY pd.LastModifiedDate ASC";

            return await _dapperHelper.ExecuteSqlReturnList<ProductDetailDto>(query);
        }
    }
}