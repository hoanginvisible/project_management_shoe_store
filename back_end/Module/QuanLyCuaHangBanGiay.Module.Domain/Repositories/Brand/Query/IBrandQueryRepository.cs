using Common.Brand.ResponseModels;

namespace Common.Repositories.Brand.Query
{
    public interface IBrandQueryRepository
    {
        Task<IEnumerable<BrandModel>> GetAllBrand();
    }
}