using Dapper;
using MediatR;
using QuanLyCuaHangBanGiay.Data.Abstract;

namespace QuanLySinhVien.Model.ProductDetail.Queries;
                
public record GetProductDetailsQuery : IRequest<IEnumerable<ProductDetailDto>> //Tham số trong IRquest là kiểu
                                                                               // dữ liệu mà nó trả về
{
    public int PageSize { get; set; } = 4;
    public int PageNumber { get; set; } = 1;
}
                                                            // kiểu dữ liệu nhận vào và kiểu dữ liệu trả về
public class GetProductDetailsQueryHandler : IRequestHandler<GetProductDetailsQuery, IEnumerable<ProductDetailDto>>
{
    private readonly IDapperHelper _dapperHelper;

    public GetProductDetailsQueryHandler(IDapperHelper dapperHelper)
    {
        _dapperHelper = dapperHelper;
    }

    public async Task<IEnumerable<ProductDetailDto>> Handle(GetProductDetailsQuery request,
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
            JOIN Size s ON s.Id = pd.IdSize
            ORDER BY pd.Id
            OFFSET @PageSize * (@PageNumber - 1) ROWS
            FETCH NEXT @PageSize ROWS ONLY";

        var parameters = new DynamicParameters();
        parameters.Add("@PageSize", request.PageSize);
        parameters.Add("@PageNumber", request.PageNumber);
        return await _dapperHelper.ExecuteSqlReturnList<ProductDetailDto>(query, parameters);
    }
}