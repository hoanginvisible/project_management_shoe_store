using Data.Interfaces;
using Domain.Entities;

namespace Service.Services.Interfaces
{
    public class BrandService : IBrandService
    {
        private IRepository<Brand> _BrandCategory;

        public BrandService(IRepository<Brand> brandRepository)
        {
            _BrandCategory = brandRepository;
        }

        public async Task<IEnumerable<Brand>> GetAllBrand()
        {
            return await _BrandCategory.GetAll();
        }

        public Task Insert(IEnumerable<Brand> entities)
        {
            return _BrandCategory.Insert(entities);
        }

        public void Update(Brand entities)
        {
            _BrandCategory.Update(entities);
        }

        public void Delete(Brand entities)
        {
            _BrandCategory.Delete(entities);
        }
    }
}