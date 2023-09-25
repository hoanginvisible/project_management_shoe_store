using Domain.Entities;

namespace Service.Services.Interfaces
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetAllBrand();
        Task Insert(IEnumerable<Brand> entities);
        void Update(Brand entities);
        void Delete(Brand entities);
    }
}