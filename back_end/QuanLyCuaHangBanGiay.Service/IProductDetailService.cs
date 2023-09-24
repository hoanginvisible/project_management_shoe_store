using QuanLyCuaHangBanGiay.Domain.Entities;
using QuanLySinhVien.Model.ProductDetail.Queries;

namespace Service;

public interface IProductDetailService
{
    Task<IEnumerable<ProductDetailDto>> GetAllProductDetail(int page);
    Task Insert(IEnumerable<Brand> entity);
    void Update(ProductDetail entity);
    void Delete(ProductDetail entity);
}