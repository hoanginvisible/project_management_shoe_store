using Domain.Entities;
using Service.Handlers.ProductDetail.Queries;

namespace Service.Services.Interfaces
{
    public interface IProductDetailService
    {
        Task<IEnumerable<ProductDetailDto>> GetAllProductDetail(int page);
        Task Insert(IEnumerable<Brand> entity);
        void Update(ProductDetail entity);
        void Delete(ProductDetail entity);
    }
}