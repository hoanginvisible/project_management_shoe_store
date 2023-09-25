using Data.Interfaces;
using MediatR;

namespace Service.Handlers.ProductDetail.Queries
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
            JOIN Product p ON p.Id = pd.IdProduct
            JOIN Brand b ON b.Id = pd.IdBrand
            JOIN Category c ON c.Id = pd.IdCategory
            JOIN Color ON Color.Id = pd.IdColor
            JOIN Images i ON i.Id = pd.IdImage
            JOIN Material m ON m.Id = pd.IdMaterial
            JOIN Size s ON s.Id = pd.IdSize";

            return await _dapperHelper.ExecuteSqlReturnList<ProductDetailDto>(query);
        }
    }
}