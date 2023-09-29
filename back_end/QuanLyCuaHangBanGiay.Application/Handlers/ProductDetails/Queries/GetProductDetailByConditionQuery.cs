using Dapper;
using Data.Interfaces;
using MediatR;

namespace Service.Handlers.ProductDetails.Queries
{
    public record GetProductDetailByConditionQuery : IRequest<IEnumerable<ProductDetailDto>>
    {
        public string Product { get; set; }
        public string Brand { get; set; }
        public string Category { get; set; }
        public string Color { get; set; }
        public string Material { get; set; }
        public string Size { get; set; }
        public double PriceMin { get; set; }
        public double PriceMax { get; set; }
        public long QuantityMin { get; set; }
        public long QuantityMax { get; set; }
    }

    public class
        GetProductDetailByConditionQueryHandler : IRequestHandler<GetProductDetailByConditionQuery,
            IEnumerable<ProductDetailDto>>
    {
        private readonly IDapperHelper _dapperHelper;

        public GetProductDetailByConditionQueryHandler(IDapperHelper dapperHelper)
        {
            _dapperHelper = dapperHelper;
        }

        public Task<IEnumerable<ProductDetailDto>> Handle(GetProductDetailByConditionQuery request,
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
                    WHERE CONTAINS(p.Name, @Product)
                    AND CONTAINS(b.Name, @Brand)
                    AND CONTAINS(c.Name, @Category)
                    AND CONTAINS(Color.Name, @Color)
                    AND CONTAINS(m.Name, @Material)
                    AND CONTAINS(s.Name, @Size)
                    AND (@PriceMin IS NULL OR @PriceMin LIKE '' OR @PriceMin <= pd.Price)
                    AND (@PriceMax IS NULL OR @PriceMin LIKE '' OR pd.Price <= @PriceMax)
                    AND (@QuantityMin IS NULL OR @QuantityMin LIKE '' OR @QuantityMin <= pd.Quantity)
                    AND (@QuantityMax IS NULL OR @QuantityMax LIKE '' OR pd.Quantity <= @QuantityMax)
                ";
            var parameters = new DynamicParameters();
            parameters.Add("@Product", $"\"*{request.Product}*\"");
            parameters.Add("@Brand", $"\"*{request.Brand}*\"");
            parameters.Add("@Category", $"\"*{request.Category}*\"");
            parameters.Add("@Color", $"\"*{request.Color}*\"");
            parameters.Add("@Material", $"\"*{request.Material}*\"");
            parameters.Add("@PageNumber", $"\"*{request.Brand}*\"");
            parameters.Add("@Size", $"\"*{request.Size}*\"");
            parameters.Add("@PriceMin", $"\"*{request.PriceMin}*\"");
            parameters.Add("@PriceMax", $"\"*{request.PriceMax}*\"");
            parameters.Add("@QuantityMin", $"\"*{request.QuantityMin}*\"");
            parameters.Add("@QuantityMax", $"\"*{request.QuantityMax}*\"");
            var result = _dapperHelper.ExecuteSqlReturnList<ProductDetailDto>(query, parameters);
            return result;
        }
    }
}